using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;

using GolfingStats.Models;
using GolfingStats.Models.ShotModels;
using GolfingStats.Pages.ShotPages;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GolfingStats.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoundHolesPage : CarouselPage
    {
        RoundModel CurrentRound;
        //Rare instance where player hits drive away, takes drop shot and replays shot num 3 from tee
        bool Reteeing = false;

        public RoundHolesPage(RoundModel round, CourseModel course)
        {
            InitializeComponent();

            Title = course.Name;

            CreateNewRound(round, course.Holes);
        }

        public RoundHolesPage(RoundModel round)
        {
            ViewPreviousRound(round);

            InitializeComponent();

            Title = round.CourseName;
        }

        /// <summary>
        /// User is playing a new round. Create a new round and display all the holes to the user.
        /// </summary>
        /// <param name="round"></param>
        /// <param name="holes"></param>
        async void CreateNewRound(RoundModel round, List<HoleModel> holes)
        {
            this.ItemsSource = await App.dataFactory.CreateNewFullRound(round, holes);
            //Removes the new round page from stack
            //TODO: Find better way to do this, makes Ui change unexpectedly
            Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 2]);
            CurrentRound = round;
        }

        /// <summary>
        /// User is viewing an old round that was played. Load that round from local storage and display all the values.
        /// </summary>
        /// <param name="round"></param>
        async void ViewPreviousRound(RoundModel round)
        {
            using (UserDialogs.Instance.Loading(null, null, null, true, MaskType.Black))
            {
                List<HoleModel> holes = await App.dataFactory.GetHolesFromRoundId(round.Id);

                foreach (HoleModel hole in holes)
                {
                    List<ShotModel> tempHoleShotList = await App.dataFactory.GetShotsFromHoleId(hole.Id);
                    hole.ShotsPlayedList = new ObservableCollection<ShotModel>(tempHoleShotList.OrderBy(x => x.ShotNumber).ToList());
                }
                
                this.ItemsSource = holes;
                CurrentRound = round;
            }
        }

        /// <summary>
        /// Returns user to the home page and saves round
        /// </summary>
        async void ReturnToHome()
        {
            await Navigation.PopToRootAsync();
            DependencyService.Get<IMessage>().ShortAlert("Round saved");
        }

        /// <summary>
        /// Changed shot picker to a button that focuses on the shot picker.
        /// Ui can now be changed on the button
        /// </summary>
        void ShotPickerFocus()
        {
            if (((HoleModel)this.SelectedItem).ShotsPlayed == 0 || Reteeing)
            {
                Reteeing = false;
                AddShot("Tee shot", new EventArgs());
            }
            else
            {
                Picker pckShotPicker = this.CurrentPage.FindByName<Picker>("pckShotPicker");
                pckShotPicker.Focus();
            }
        }

        /// <summary>
        /// Is called when the user taps on the add shot button.
        /// The code will check which shot type was selected and navigate the user
        /// to the corresponding page to add that type of shot.
        /// </summary>
        async void AddShot(object sender, EventArgs args)
        {
            // Picker.SelectedIndex had to be used else when setting it back to -1 exp is thrown.
            // This is the best solution for now
            //====================================================
            string ShotAddType = null;
            if (sender.GetType() == typeof(Picker))
            {
                switch (((Picker)sender).SelectedIndex)
                {
                    case 0:
                        ShotAddType = "Approach";
                        break;
                    case 1:
                        ShotAddType = "Chip";
                        break;
                    case 2:
                        ShotAddType = "Putt";
                        break;
                    case 3:
                        ShotAddType = "Drop shot";
                        break;
                }
                ((Picker)sender).SelectedIndex = -1;
            }
            else if (sender.GetType() == typeof(string))
            {
                ShotAddType = sender.ToString();
            }
            //====================================================

            HoleModel holeModel = (HoleModel)this.SelectedItem;
            ShotModel PrevShotHit = new ShotModel();

            int holeId = holeModel.Id;
            int roundId = holeModel.RoundId;
            int shotNum = holeModel.ShotsPlayed + 1; //Lets the page know what number shot is being hit
            int par = holeModel.Par;

            if (((HoleModel)this.SelectedItem).ShotsPlayedList.Count != 0)
                PrevShotHit = ((HoleModel)this.SelectedItem).ShotsPlayedList.LastOrDefault() as ShotModel;
            else
                PrevShotHit.DistanceLeftToHole = ((HoleModel)this.SelectedItem).HoleDistance;

            if (ShotAddType == "Tee shot" && par != 3)
            {
                DriveDetailsPage driveDetailsPage = new DriveDetailsPage(roundId, holeId, shotNum, holeModel.HoleDistance);
                driveDetailsPage.ShotSaved += ShotSaved;
                await Navigation.PushModalAsync(driveDetailsPage);
            }

            if (ShotAddType == "Approach" || (ShotAddType == "Tee shot" && par == 3))
            {
                ApproachDetailsPage fairwayDetailsPage = new ApproachDetailsPage(roundId, holeId, shotNum, PrevShotHit);
                fairwayDetailsPage.ShotSaved += ShotSaved;
                await Navigation.PushModalAsync(fairwayDetailsPage);
            }
            else if (ShotAddType == "Chip")
            {
                ChipDetailsPage chipDetailsPage = new ChipDetailsPage(roundId, holeId, shotNum, PrevShotHit);
                chipDetailsPage.ShotSaved += ShotSaved;
                await Navigation.PushModalAsync(chipDetailsPage);
            }
            else if (ShotAddType == "Putt")
            {
                PuttDetailsPage puttDetailsPage = new PuttDetailsPage(roundId, holeId, shotNum, PrevShotHit);
                puttDetailsPage.ShotSaved += ShotSaved;
                await Navigation.PushModalAsync(puttDetailsPage);
            }
            else if (ShotAddType == "Drop shot")
            {
                DropShotDetailsPage dropDetailsPage = new DropShotDetailsPage(roundId, holeId, shotNum);
                dropDetailsPage.ShotSaved += ShotSaved;
                await Navigation.PushModalAsync(dropDetailsPage);
            }
        }

        /// <summary>
        /// Closes the modal for adding a shot and returns the details of the shot added.
        /// Details returned are updated on the holepage.
        /// The hole is also updated in local storage to keep details up to date.
        /// </summary>
        async void ShotSaved(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync(true);

            bool NewShotCreated = true;

            HoleModel HolePage = (HoleModel)this.SelectedItem;
            ShotModel shotReturned = (ShotModel)sender;

            //Check if the shot is already in the listview itemsource and update if found
            for (int i = 0; i < HolePage.ShotsPlayedList.Count; i++)
            {
                if (HolePage.ShotsPlayedList[i].Id == shotReturned.Id && HolePage.ShotsPlayedList[i].GetType() == shotReturned.GetType())
                {
                    HolePage.ShotsPlayedList[i] = shotReturned;
                    NewShotCreated = false;

                    if (shotReturned.ShotNumber == 1 || shotReturned.ShotNumber == 2 || shotReturned.ShotNumber == 3)
                        await App.dataFactory.UpdateHole(CheckGIRFIR(HolePage, shotReturned));

                    if (!CurrentRound.ReloadStats)
                    {
                        CurrentRound.ReloadStats = true;
                        await App.dataFactory.UpdateRound(CurrentRound);
                    }
                }
            }

            //Adds a new shot if it was not found in the list
            if (NewShotCreated)
            {
                HolePage.ShotsPlayedList.Add(shotReturned);

                if (shotReturned.GetType() == typeof(DropShotModel))
                    if (((DropShotModel)shotReturned).ShotNumber == 2 && ((DropShotModel)shotReturned).DropPosition == "Replay previous shot")
                        Reteeing = true; //TODO: Add ability to retee multiple times (For worst case scenarios..)

                HolePage.ShotsPlayed += 1;
                await App.dataFactory.UpdateHole(CheckGIRFIR(HolePage, shotReturned));

                CurrentRound.ShotsTotal += 1;
                CurrentRound.ReloadStats = true;
                await App.dataFactory.UpdateRound(CurrentRound);
            }
        }

        /// <summary>
        /// Closes the modal for adding a shot and returns the details of the shot added.
        /// Deletes the shot from the listview.
        /// The hole is also updated in local storage to keep details up to date.
        /// (Only way to update listview to display all shots is by adding the itemsource from a different class)
        /// </summary>
        async void ShotDeleted(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync(true);

            HoleModel HolePage = (HoleModel)this.SelectedItem;
            ShotModel shotReturned = (ShotModel)sender;
            
            //Delete the shot from the listview
            for (int i = 0; i < HolePage.ShotsPlayedList.Count(); i++)
            {
                if (HolePage.ShotsPlayedList[i].Id == shotReturned.Id)
                {
                    HolePage.ShotsPlayedList.RemoveAt(i);
                    i--;
                }
                else if (HolePage.ShotsPlayedList[i].ShotNumber > shotReturned.ShotNumber)
                {
                    HolePage.ShotsPlayedList[i].ShotNumber -= 1;
                    if (HolePage.ShotsPlayedList[i].GetType() == typeof(DriveModel))
                        await App.dataFactory.UpdateShot((DriveModel)HolePage.ShotsPlayedList[i]);
                    if (HolePage.ShotsPlayedList[i].GetType() == typeof(ApproachModel))
                        await App.dataFactory.UpdateShot((ApproachModel)HolePage.ShotsPlayedList[i]);
                    if (HolePage.ShotsPlayedList[i].GetType() == typeof(ChipModel))
                        await App.dataFactory.UpdateShot((ChipModel)HolePage.ShotsPlayedList[i]);
                    if (HolePage.ShotsPlayedList[i].GetType() == typeof(PuttModel))
                        await App.dataFactory.UpdateShot((PuttModel)HolePage.ShotsPlayedList[i]);
                    if (HolePage.ShotsPlayedList[i].GetType() == typeof(DropShotModel))
                        await App.dataFactory.UpdateShot((DropShotModel)HolePage.ShotsPlayedList[i]);
                }
            }

            HolePage.ShotsPlayed -= 1;
            await App.dataFactory.UpdateHole(HolePage);

            CurrentRound.ShotsTotal -= 1;
            CurrentRound.ReloadStats = true;
            await App.dataFactory.UpdateRound(CurrentRound);

            DependencyService.Get<IMessage>().ShortAlert("Shot deleted");
        }

        /// <summary>
        /// Opens the selected shot in the listview that was tapped
        /// </summary>
        void OnShotTapped(ListView sender, EventArgs args)
        {
            if (sender.SelectedItem.GetType() == typeof(DriveModel))
            {
                DriveDetailsPage driveDetailsPage = new DriveDetailsPage((DriveModel)sender.SelectedItem);
                driveDetailsPage.ShotSaved += ShotSaved;
                driveDetailsPage.ShotDeleted += ShotDeleted;
                Navigation.PushModalAsync(driveDetailsPage);
            }
            else if (sender.SelectedItem.GetType() == typeof(ApproachModel))
            {
                ApproachDetailsPage fairwayDetailsPage = new ApproachDetailsPage((ApproachModel)sender.SelectedItem);
                fairwayDetailsPage.ShotSaved += ShotSaved;
                fairwayDetailsPage.ShotDeleted += ShotDeleted;
                Navigation.PushModalAsync(fairwayDetailsPage);
            }
            else if (sender.SelectedItem.GetType() == typeof(ChipModel))
            {
                ChipDetailsPage chipDetailsPage = new ChipDetailsPage((ChipModel)sender.SelectedItem);
                chipDetailsPage.ShotSaved += ShotSaved;
                chipDetailsPage.ShotDeleted += ShotDeleted;
                Navigation.PushModalAsync(chipDetailsPage);
            }
            else if (sender.SelectedItem.GetType() == typeof(PuttModel))
            {
                PuttDetailsPage puttDetailsPage = new PuttDetailsPage((PuttModel)sender.SelectedItem);
                puttDetailsPage.ShotSaved += ShotSaved;
                puttDetailsPage.ShotDeleted += ShotDeleted;
                Navigation.PushModalAsync(puttDetailsPage);
            }
            else if (sender.SelectedItem.GetType() == typeof(DropShotModel))
            {
                DropShotDetailsPage dropDetailsPage = new DropShotDetailsPage((DropShotModel)sender.SelectedItem);
                dropDetailsPage.ShotSaved += ShotSaved;
                dropDetailsPage.ShotDeleted += ShotDeleted;
                Navigation.PushModalAsync(dropDetailsPage);
            }

            sender.SelectedItem = null;
        }

        /// <summary>
        /// Mehtod to check when the GIR and FIR switches should be switched when a new shot is created
        /// </summary>
        HoleModel CheckGIRFIR(HoleModel holePlayed, ShotModel shotReturned)
        {
            if (holePlayed.Par == 3)
            {
                if (shotReturned.ShotNumber == 1)
                    if (shotReturned.GetType() == typeof(ApproachModel))
                        if (((ApproachModel)shotReturned).OnGreen == true)
                            holePlayed.GIR = true;
                        else
                            holePlayed.GIR = false;
            }
            else if (holePlayed.Par == 4)
            {
                if (shotReturned.ShotNumber == 1)
                {
                    if (shotReturned.GetType() == typeof(DriveModel))
                        if (((DriveModel)shotReturned).OnFairway == true)
                            holePlayed.FIR = true;
                        else
                            holePlayed.FIR = false;
                }
                else if (shotReturned.ShotNumber == 2)
                {
                    if (shotReturned.GetType() == typeof(ApproachModel))
                        if (((ApproachModel)shotReturned).OnGreen == true)
                            holePlayed.GIR = true;
                        else
                            holePlayed.GIR = false;
                    else if (shotReturned.GetType() == typeof(ChipModel))
                        if (((ChipModel)shotReturned).OnGreen == true)
                            holePlayed.GIR = true;
                        else
                            holePlayed.GIR = false;
                }
            }
            else if (holePlayed.Par == 5)
            {
                if (shotReturned.ShotNumber == 1)
                {
                    if (shotReturned.GetType() == typeof(DriveModel))
                        if (((DriveModel)shotReturned).OnFairway == true)
                            holePlayed.FIR = true;
                        else
                            holePlayed.FIR = false;
                }
                else if (shotReturned.ShotNumber == 2 || shotReturned.ShotNumber == 3)
                {
                    if (shotReturned.GetType() == typeof(ApproachModel))
                        if (((ApproachModel)shotReturned).OnGreen == true)
                            holePlayed.GIR = true;
                        else
                            holePlayed.GIR = false;
                    else if (shotReturned.GetType() == typeof(ChipModel))
                        if (((ChipModel)shotReturned).OnGreen == true)
                            holePlayed.GIR = true;
                        else
                            holePlayed.GIR = false;
                }
            }

            return holePlayed;
        }

        /// <summary>
        /// Takes user to the previous hole when the button is pressed
        /// (Also goes to the last hole when one the first)
        /// </summary>
        void GoPreviousHolePage()
        {
            //TODO: TEST!!!!!!!!!!!!
            Task.Delay(2000);
            int currentPageNum = ((HoleModel)this.SelectedItem).HoleNumber - 1;

            if (currentPageNum == 0)
            {
                this.CurrentPage = this.Children[17];
            }
            else
            {
                currentPageNum--;
                this.CurrentPage = this.Children[currentPageNum];
            }
        }

        /// <summary>
        /// Takes user tp the next hole when the button is pressed
        /// (Also goes to the first hole when on the last)
        /// </summary>
        void GoNextHolePage()
        {
            //TODO: TEST!!!!!!!!!!!!
            Task.Delay(2000);
            int currentPageNum = ((HoleModel)this.SelectedItem).HoleNumber - 1;

            if (currentPageNum == 17)
            {
                this.CurrentPage = this.Children[0];
            }
            else
            {
                currentPageNum++;
                this.CurrentPage = this.Children[currentPageNum];
            }
        }
    }
}