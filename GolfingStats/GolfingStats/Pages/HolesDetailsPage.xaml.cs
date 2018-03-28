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
            this.ItemsSource = await App.dataFactory.GetHolesFromRoundId(round.Id);
        }

        /// <summary>
        /// Update all the holes that was played in local storage
        /// </summary>
        async void Save()
        {
            await App.dataFactory.UpdateHoles(this.ItemsSource.Cast<HoleModel>());

            await Navigation.PopToRootAsync();
        }

        async void UpdateShotsListview(object sender, EventArgs e)
        {
            HoleModel HolePage = (HoleModel)this.SelectedItem;
            //List<ShotModel> shotReturned = await App.dataFactory.GetShotsFromHoleId(HolePage.Id);

            //Add Bool to check if check has been done already and not check again if true
            if (HolePage.ShotsPlayedList.Count == 0)
            {
                //Shots played list
                ListView lwShotsPlayed = this.CurrentPage.FindByName<ListView>("lwShotsPlayed");
                HolePage.ShotsPlayedList = await App.dataFactory.GetShotsFromHoleId(HolePage.Id);
                lwShotsPlayed.ItemsSource = HolePage.ShotsPlayedList;

                //Shots played label
                Label lblShotsPlayed = this.CurrentPage.FindByName<Label>("lblShotsPlayed");
                lblShotsPlayed.Text = HolePage.ShotsPlayed.ToString();
            }
        }

        /// <summary>
        /// Is called when the user taps on the add shot button.
        /// The code will check which shot type was selected and navigate the user
        /// to the corresponding page to add that type of shot.
        /// </summary>
        void AddShot(object sender, EventArgs args)
        {
            Picker picker = (Picker)sender;
            HoleModel holeModel = (HoleModel)this.SelectedItem;

            int holeId = holeModel.Id;
            int roundId = holeModel.RoundId;
            int shotNum = holeModel.ShotsPlayed + 1; //Lets the page know what number shot is being hit
            int par = holeModel.Par;

            if (picker.SelectedIndex == 0 && par != 3)
            {
                DriveDetailsPage driveDetailsPage = new DriveDetailsPage(roundId, holeId, shotNum);
                driveDetailsPage.ShotSaved += ShotSaved;
                Navigation.PushModalAsync(driveDetailsPage);
            }
            else if (picker.SelectedIndex == 1 || (picker.SelectedIndex == 0 && par == 3))
            {
                FairwayDetailsPage fairwayDetailsPage = new FairwayDetailsPage(roundId, holeId, shotNum);
                fairwayDetailsPage.ShotSaved += ShotSaved;
                Navigation.PushModalAsync(fairwayDetailsPage);
            }
            else if (picker.SelectedIndex == 2)
            {
                ChipDetailsPage chipDetailsPage = new ChipDetailsPage(roundId, holeId, shotNum);
                chipDetailsPage.ShotSaved += ShotSaved;
                Navigation.PushModalAsync(chipDetailsPage);
            }
            else if (picker.SelectedIndex == 3)
            {
                PuttDetailsPage puttDetailsPage = new PuttDetailsPage(roundId, holeId, shotNum);
                puttDetailsPage.ShotSaved += ShotSaved;
                Navigation.PushModalAsync(puttDetailsPage);
            }

            picker.SelectedIndex = -1;
        }

        /// <summary>
        /// Closes the modal for adding a shot and returns the details of the shot added.
        /// Details returned are updated on the holepage.
        /// (Only way to update listview to display all shots is by adding the itemsource from a different class)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void ShotSaved(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync(true);

            bool NewShotCreated = true;

            HoleModel HolePage = (HoleModel)this.SelectedItem;
            ShotModel shotReturned = (ShotModel)sender;

            //Check if the shot is already in the listview itemsource and update if found
            for (int i = 0; i < HolePage.ShotsPlayedList.Count; i++)
            {
                if (HolePage.ShotsPlayedList[i].Id == shotReturned.Id)
                {
                    HolePage.ShotsPlayedList[i] = shotReturned;
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
            }
        }

        void OnShotTapped(ListView sender, EventArgs args)
        {
            if (sender.SelectedItem.GetType() == typeof(DriveModel))
            {
                DriveDetailsPage driveDetailsPage = new DriveDetailsPage((DriveModel)sender.SelectedItem);
                driveDetailsPage.ShotSaved += ShotSaved;
                Navigation.PushModalAsync(driveDetailsPage);
            }
            else if (sender.SelectedItem.GetType() == typeof(FairwayModel))
            {
                FairwayDetailsPage fairwayDetailsPage = new FairwayDetailsPage((FairwayModel)sender.SelectedItem);
                fairwayDetailsPage.ShotSaved += ShotSaved;
                Navigation.PushModalAsync(fairwayDetailsPage);
            }
            else if (sender.SelectedItem.GetType() == typeof(ChipModel))
            {
                ChipDetailsPage chipDetailsPage = new ChipDetailsPage((ChipModel)sender.SelectedItem);
                chipDetailsPage.ShotSaved += ShotSaved;
                Navigation.PushModalAsync(chipDetailsPage);
            }
            else if (sender.SelectedItem.GetType() == typeof(PuttModel))
            {
                PuttDetailsPage puttDetailsPage = new PuttDetailsPage((PuttModel)sender.SelectedItem);
                puttDetailsPage.ShotSaved += ShotSaved;
                Navigation.PushModalAsync(puttDetailsPage);
            }

            sender.SelectedItem = null;
        }
    }
}