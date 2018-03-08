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
        public HomePage ()
		{
            this.Title = "All Rounds";

			InitializeComponent ();
		}

        public async void NavRoundPage()
        {
            //TODO: Send the round played object to the next page
            RoundModel roundPlayed = new RoundModel();

            await Navigation.PushAsync(new Pages.RoundDetailsPage(), true);
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
            List<RoundModel> data = await App.dataFactory.GetAllRounds();

            DisplayList.ItemsSource = data;
        }

        public async void OnGetHolesButtonClicked(object sender, EventArgs args)
        {
            List<HoleModel> data = await App.dataFactory.GetAllHoles();

            DisplayList.ItemsSource = data;
        }

        public async void OnGetDriveButtonClicked(object sender, EventArgs args)
        {
            List<DriveModel> data = await App.dataFactory.GetAllShotsDrive();

            DisplayList.ItemsSource = data;
        }

        public async void OnGetFairwayButtonClicked(object sender, EventArgs args)
        {
            List<FairwayModel> data = await App.dataFactory.GetAllShotsFairway();

            DisplayList.ItemsSource = data;
        }

        public async void OnGetChipButtonClicked(object sender, EventArgs args)
        {
            List<ChipModel> data = await App.dataFactory.GetAllShotsChip();

            DisplayList.ItemsSource = data;
        }

        public async void OnGetPuttButtonClicked(object sender, EventArgs args)
        {
            List<PuttModel> data = await App.dataFactory.GetAllShotsPutt();

            DisplayList.ItemsSource = data;
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