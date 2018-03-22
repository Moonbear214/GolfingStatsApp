using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GolfingStats.Models;
using GolfingStats.Models.ShotModels;

namespace GolfingStats
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "All Rounds";

            InitializeComponent();
        }

        public async void NavRoundPage()
        {
            //TODO: Send the round played object to the next page
            //RoundModel roundPlayed = new RoundModel();

            await Navigation.PushAsync(new Pages.RoundDetailsPage(), true);
        }

        public async void NavAddCoursePage()
        {
            if (string.IsNullOrEmpty(entCourseName.Text))
            {
                await DisplayAlert("Ai...", "Dammit Neldan..", "Cancel");
            }
            else
            {
                CourseModel course = await App.dataFactory.CreateNewCourse(entCourseName.Text);

                await Navigation.PushAsync(new Pages.AddHolesPage(course), true);
            }
        }


        public async void DisplayListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is DriveModel)
            {
                DriveModel shot = (DriveModel)e.SelectedItem;
                shot.HoleId += 11;

                await App.dataFactory.UpdateShot(shot);
            }
            else if (e.SelectedItem is FairwayModel)
            {
                FairwayModel shot = (FairwayModel)e.SelectedItem;
                shot.HoleId += 11;

                await App.dataFactory.UpdateShot(shot);
            }
            else if (e.SelectedItem is ChipModel)
            {
                ChipModel shot = (ChipModel)e.SelectedItem;
                shot.HoleId += 11;

                await App.dataFactory.UpdateShot(shot);
            }
            else if (e.SelectedItem is PuttModel shot)
            {
                shot.HoleId += 11;

                await App.dataFactory.UpdateShot(shot);
            }

        }


        //========================================================================================================================================================================
        //!!!!MUST BE DELETED!!!!
        //===============================================
        //Clear local Storage
        public void OnClearLocalStorageButtonClicked()
        {
            App.dataFactory.ClearLocalStorage();
        }
        //===============================================


        //Creates a full round with all holes included
        public void OnCreateFullRoundButtonClicked(object sender, EventArgs args)
        {
            App.dataFactory.CreateFullRoundDummy();
        }

        //Get dummy data for all Models
        public async void OnGetRoundsButtonClicked(object sender, EventArgs args)
        {
            DisplayList.ItemsSource = await App.dataFactory.GetAllRounds();
        }

        public async void OnGetHolesButtonClicked(object sender, EventArgs args)
        {
            DisplayList.ItemsSource = await App.dataFactory.GetAllHoles();
        }

        public async void OnGetDriveButtonClicked(object sender, EventArgs args)
        {
            DisplayList.ItemsSource = await App.dataFactory.GetAllShotsDrive();
        }

        public async void OnGetFairwayButtonClicked(object sender, EventArgs args)
        {
            DisplayList.ItemsSource = await App.dataFactory.GetAllShotsFairway();
        }

        public async void OnGetChipButtonClicked(object sender, EventArgs args)
        {
            DisplayList.ItemsSource = await App.dataFactory.GetAllShotsChip();
        }

        public async void OnGetPuttButtonClicked(object sender, EventArgs args)
        {
            DisplayList.ItemsSource = await App.dataFactory.GetAllShotsPutt();
        }

        public async void OnGetAllShotsButtonClicked(object sender, EventArgs args)
        {
            DisplayList.ItemsSource = await App.dataFactory.GetAllShots();
        }


        //Add One dummy data for all Models
        public void OnAddRoundsButtonClicked(object sender, EventArgs args)
        {
            App.dataFactory.AddDummyRound();
        }

        public void OnAddHolesButtonClicked(object sender, EventArgs args)
        {
            App.dataFactory.AddDummyHole();
        }

        public void OnAddDriveButtonClicked(object sender, EventArgs args)
        {
            App.dataFactory.AddDummyShotDrive();
        }

        public void OnAddFairwayButtonClicked(object sender, EventArgs args)
        {
            App.dataFactory.AddDummyShotFairway();
        }

        public void OnAddChipButtonClicked(object sender, EventArgs args)
        {
            App.dataFactory.AddDummyShotChip();
        }

        public void OnAddPuttButtonClicked(object sender, EventArgs args)
        {
            App.dataFactory.AddDummyShotPutt();
        }
        //========================================================================================================================================================================
    }
}