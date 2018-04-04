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

            GetDisplayAllRounds();

            this.Appearing += HomePage_Appearing;
        }

        /// <summary>
        /// Gets and displays all the rounds that are saved in local storage as soon as the page will appear
        /// </summary>
        private void HomePage_Appearing(object sender, EventArgs e)
        {
            GetDisplayAllRounds();
        }

        async void GetDisplayAllRounds()
        {
            lwRoundsPlayed.ItemsSource = await App.dataFactory.GetAllRounds();
            if (((List<RoundModel>)lwRoundsPlayed.ItemsSource).Count == 0)
                lblEmptyList.IsVisible = true;
            else
                lblEmptyList.IsVisible = false;
        }

        /// <summary>
        /// Navigate to the round page to create a new round
        /// </summary>
        async void NavNewRoundPage()
        {
            await Navigation.PushAsync(new Pages.RoundDetailsPage(), true);
        }

        /// <summary>
        /// Navigate to all courses page
        /// </summary>
        async void NavCoursesPage()
        {
            await Navigation.PushAsync(new Pages.AllCoursesPage(), true);
        }

        /// <summary>
        /// Takes user to the round details page for the round that was tapped
        /// </summary>
        async void OnRoundTapped(ListView sender, EventArgs args)
        {
            await Navigation.PushAsync(new Pages.RoundDetailsPage((RoundModel)sender.SelectedItem), true);
        }

        //========================================================================================================================================================================
        // Methods for testing and debugging
        //========================================================================================================================================================================

        //!!!!MUST BE DELETED!!!!
        //===============================================
        //===============================================
        //Clear local Storage
        //public void OnClearLocalStorageButtonClicked()
        //{
        //    App.dataFactory.ClearLocalStorage();
        //}
        //===============================================
        //===============================================


        ////Creates a full round with all holes included
        //public void OnCreateFullRoundButtonClicked(object sender, EventArgs args)
        //{
        //    App.dataFactory.CreateFullRoundDummy();
        //}

        ////Get dummy data for all Models
        //public async void OnGetRoundsButtonClicked(object sender, EventArgs args)
        //{
        //    DisplayList.ItemsSource = await App.dataFactory.GetAllRounds();
        //}

        //public async void OnGetHolesButtonClicked(object sender, EventArgs args)
        //{
        //    DisplayList.ItemsSource = await App.dataFactory.GetAllHoles();
        //}

        //public async void OnGetDriveButtonClicked(object sender, EventArgs args)
        //{
        //    DisplayList.ItemsSource = await App.dataFactory.GetAllShotsDrive();
        //}

        //public async void OnGetFairwayButtonClicked(object sender, EventArgs args)
        //{
        //    DisplayList.ItemsSource = await App.dataFactory.GetAllShotsFairway();
        //}

        //public async void OnGetChipButtonClicked(object sender, EventArgs args)
        //{
        //    DisplayList.ItemsSource = await App.dataFactory.GetAllShotsChip();
        //}

        //public async void OnGetPuttButtonClicked(object sender, EventArgs args)
        //{
        //    DisplayList.ItemsSource = await App.dataFactory.GetAllShotsPutt();
        //}

        //public async void OnGetAllShotsButtonClicked(object sender, EventArgs args)
        //{
        //    DisplayList.ItemsSource = await App.dataFactory.GetAllShots();
        //}


        ////Add One dummy data for all Models
        //public void OnAddRoundsButtonClicked(object sender, EventArgs args)
        //{
        //    App.dataFactory.AddDummyRound();
        //}

        //public void OnAddHolesButtonClicked(object sender, EventArgs args)
        //{
        //    App.dataFactory.AddDummyHole();
        //}

        //public void OnAddDriveButtonClicked(object sender, EventArgs args)
        //{
        //    App.dataFactory.AddDummyShotDrive();
        //}

        //public void OnAddFairwayButtonClicked(object sender, EventArgs args)
        //{
        //    App.dataFactory.AddDummyShotFairway();
        //}

        //public void OnAddChipButtonClicked(object sender, EventArgs args)
        //{
        //    App.dataFactory.AddDummyShotChip();
        //}

        //public void OnAddPuttButtonClicked(object sender, EventArgs args)
        //{
        //    App.dataFactory.AddDummyShotPutt();
        //}
        //========================================================================================================================================================================
    }
}