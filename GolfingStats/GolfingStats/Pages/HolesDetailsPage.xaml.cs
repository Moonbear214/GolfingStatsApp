using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GolfingStats.Models;
using GolfingStats.Models.ShotModels;
using GolfingStats.Pages.ShotPages;

namespace GolfingStats.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HolesDetailsPage : CarouselPage
    {
        int DistanceLeftToHole;

        public HolesDetailsPage(RoundModel round, CourseModel course)
        {
            InitializeComponent();

            Title = course.Name;

            CreateNewRound(round, course.Holes);
        }

        public HolesDetailsPage(RoundModel round)
        {
            InitializeComponent();

            Title = round.CourseName;

            this.CurrentPageChanged += UpdateShotsListview;

            ViewPreviousRound(round);
        }

        /// <summary>
        /// User is playing a new round. Create a new round and display all the holes to the user.
        /// </summary>
        /// <param name="round"></param>
        /// <param name="holes"></param>
        async void CreateNewRound(RoundModel round, List<HoleModel> holes)
        {
            this.ItemsSource = await App.dataFactory.CreateNewFullRound(round, holes);
        }

        /// <summary>
        /// User is viewing an old round that was played. Load that round from local storage and display all the values.
        /// </summary>
        /// <param name="round"></param>
        async void ViewPreviousRound(RoundModel round)
        {
            List<HoleModel> holes = await App.dataFactory.GetHolesFromRoundId(round.Id);

            List<int> holeIds = new List<int>();
            foreach (HoleModel hole in holes)
            {
                holeIds.Add(hole.Id);
            }

            List<ShotModel> ShotsPlayed = await App.dataFactory.GetShotsFromHoleIdList(holeIds);

            foreach (HoleModel hole in holes)
            {
                foreach (ShotModel shot in ShotsPlayed)
                {
                    if (shot.HoleId == hole.Id)
                    {
                        hole.ShotsPlayedList.Add(shot);
                    }
                }
            }

            this.ItemsSource = holes;
        }

        /// <summary>
        /// Update all the holes that was played in local storage
        /// </summary>
        async void Save()
        {
            await App.dataFactory.UpdateHoles(this.ItemsSource.Cast<HoleModel>());

            await Navigation.PopToRootAsync();
        }

        void UpdateShotsListview(object sender, EventArgs e)
        {
            //Shots played list
            ListView lwShotsPlayed = this.CurrentPage.FindByName<ListView>("lwShotsPlayed");
            if (lwShotsPlayed.ItemsSource == null)
                lwShotsPlayed.ItemsSource = ((HoleModel)this.SelectedItem).ShotsPlayedList;

            //Shots played label
            Label lblShotsPlayed = this.CurrentPage.FindByName<Label>("lblShotsPlayed");
            lblShotsPlayed.Text = ((HoleModel)this.SelectedItem).ShotsPlayed.ToString();
            
        }

        /// <summary>
        /// Is called when the user taps on the add shot button.
        /// The code will check which shot type was selected and navigate the user
        /// to the corresponding page to add that type of shot.
        /// </summary>
        async void AddShot(object sender, EventArgs args)
        {
            Picker picker = (Picker)sender;
            HoleModel holeModel = (HoleModel)this.SelectedItem;

            int holeId = holeModel.Id;
            int roundId = holeModel.RoundId;
            int shotNum = holeModel.ShotsPlayed + 1; //Lets the page know what number shot is being hit
            int par = holeModel.Par;

            if (picker.SelectedIndex == 0 && par != 3)
            {
                DriveDetailsPage driveDetailsPage = new DriveDetailsPage(roundId, holeId, shotNum, holeModel.HoleDistance);
                driveDetailsPage.ShotSaved += ShotSaved;
                await Navigation.PushModalAsync(driveDetailsPage);
            }
            else if (picker.SelectedIndex == 1 || (picker.SelectedIndex == 0 && par == 3))
            {
                FairwayDetailsPage fairwayDetailsPage = new FairwayDetailsPage(roundId, holeId, shotNum, DistanceLeftToHole);
                fairwayDetailsPage.ShotSaved += ShotSaved;
                await Navigation.PushModalAsync(fairwayDetailsPage);
            }
            else if (picker.SelectedIndex == 2)
            {
                ChipDetailsPage chipDetailsPage = new ChipDetailsPage(roundId, holeId, shotNum, DistanceLeftToHole);
                chipDetailsPage.ShotSaved += ShotSaved;
                await Navigation.PushModalAsync(chipDetailsPage);
            }
            else if (picker.SelectedIndex == 3)
            {
                PuttDetailsPage puttDetailsPage = new PuttDetailsPage(roundId, holeId, shotNum, DistanceLeftToHole);
                puttDetailsPage.ShotSaved += ShotSaved;
                await Navigation.PushModalAsync(puttDetailsPage);
            }

            picker.SelectedIndex = -1;
        }

        /// <summary>
        /// Closes the modal for adding a shot and returns the details of the shot added.
        /// Details returned are updated on the holepage.
        /// The hole is also updated in local storage to keep details up to date.
        /// (Only way to update listview to display all shots is by adding the itemsource from a different class)
        /// </summary>
        async void ShotSaved(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync(true);

            bool NewShotCreated = true;

            HoleModel HolePage = (HoleModel)this.SelectedItem;
            ShotModel shotReturned = (ShotModel)sender;

            DistanceLeftToHole = shotReturned.DistanceLeftToHole;

            //Check if the shot is already in the listview itemsource and update if found
            for (int i = 0; i < HolePage.ShotsPlayedList.Count; i++)
            {
                if (HolePage.ShotsPlayedList[i].Id == shotReturned.Id)
                {
                    //Shots played list
                    ListView lwShotsPlayed = this.CurrentPage.FindByName<ListView>("lwShotsPlayed");
                    HolePage.ShotsPlayedList[i] = shotReturned;
                    lwShotsPlayed.ItemsSource = HolePage.ShotsPlayedList;
                    NewShotCreated = false;
                }
            }

            //Adds a new shot if it was not found in the list
            if (NewShotCreated)
            {
                //Shots played list
                ListView lwShotsPlayed = this.CurrentPage.FindByName<ListView>("lwShotsPlayed");
                HolePage.ShotsPlayedList.Add(shotReturned);
                lwShotsPlayed.ItemsSource = HolePage.ShotsPlayedList;

                //Shots played label
                Label lblShotsPlayed = this.CurrentPage.FindByName<Label>("lblShotsPlayed");
                HolePage.ShotsPlayed = Int32.Parse(lblShotsPlayed.Text) + 1;
                lblShotsPlayed.Text = HolePage.ShotsPlayed.ToString();

                await App.dataFactory.UpdateHole((HoleModel)this.SelectedItem);
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
            for (int i = 0; i < HolePage.ShotsPlayedList.Count; i++)
            {
                if (HolePage.ShotsPlayedList[i].Id == shotReturned.Id)
                {
                    //Shots played list
                    ListView lwShotsPlayed = this.CurrentPage.FindByName<ListView>("lwShotsPlayed");
                    HolePage.ShotsPlayedList.RemoveAt(i);
                    lwShotsPlayed.ItemsSource = HolePage.ShotsPlayedList;

                    //Shots played label
                    Label lblShotsPlayed = this.CurrentPage.FindByName<Label>("lblShotsPlayed");
                    HolePage.ShotsPlayed = Int32.Parse(lblShotsPlayed.Text) - 1;
                    lblShotsPlayed.Text = HolePage.ShotsPlayed.ToString();

                    await App.dataFactory.UpdateHole((HoleModel)this.SelectedItem);
                }
            }
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
            else if (sender.SelectedItem.GetType() == typeof(FairwayModel))
            {
                FairwayDetailsPage fairwayDetailsPage = new FairwayDetailsPage((FairwayModel)sender.SelectedItem);
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

            sender.SelectedItem = null;
        }

        void ShotPickerFocus()
        {
            Picker pckShotPicker = this.CurrentPage.FindByName<Picker>("pckShotPicker");
            pckShotPicker.Focus();
        }

        void GoPreviousShotPage()
        {
            var currentPage = 0;

            this.CurrentPage = this.Children[currentPage];

            if (currentPage == 18)
            {
                currentPage = 0;
            }
            else
            {
                currentPage++;
            }

        }

        void GoNextShotPage()
        {

        }
    }
}