using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GolfingStats.Models.ShotModels;

namespace GolfingStats.Pages.ShotPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FairwayDetailsPage : ContentPage
    {
        public event EventHandler ShotSaved;
        public event EventHandler ShotDeleted;

        public FairwayDetailsPage (int roundId, int holeId, int shotNum)
        {
            FairwayModel fairwayModel = new FairwayModel() { RoundId = roundId, HoleId = holeId, ShotNumber = shotNum };
            this.BindingContext = fairwayModel;

			InitializeComponent ();
            PageSetup();
        }

        public FairwayDetailsPage (FairwayModel fairwayModel)
        {
            this.BindingContext = fairwayModel;

            InitializeComponent();
            btnDeleteShot.IsVisible = true;
            PageSetup();
        }

        /// <summary>
        /// Setup the visual elements of the page (Hide objects that aren't necessary, setup click events ect.)
        /// </summary>
        void PageSetup()
        {
            //Wind pickers show, hide, reset
            //===========================================================
            if (pckWindForce.SelectedItem.ToString() == "None")
                grdWindDirection.IsVisible = false;

            pckWindForce.SelectedIndexChanged += PckWindForce_SelectedIndexChanged;
            //===========================================================

            //On/Off Fairway 
            //===========================================================
            if (swcOnGreen.IsToggled)
                grdOffGreen.IsVisible = false;
            else
                grdOnGreen.IsVisible = false;

            swcOnGreen.Toggled += SwcOnGreen_Toggled;
            //===========================================================
        }

        /// <summary>
        /// Displays the direction of the wind picker if there is a wind that is blowing
        /// </summary>
        private void PckWindForce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Picker)sender).SelectedItem.ToString() != "None")
            {
                grdWindDirection.IsVisible = true;
                pckWindDirection.SelectedIndex = -1;
            }
            else
                grdWindDirection.IsVisible = false;
        }

        /// <summary>
        /// Displays either on green values or off green values deppending on what the user chose
        /// </summary>
        private void SwcOnGreen_Toggled(object sender, ToggledEventArgs e)
        {
            if (((Switch)sender).IsToggled)
            {
                grdOffGreen.IsVisible = false;
                grdOnGreen.IsVisible = true;
                pckPosToGreenHorz.SelectedIndex = -1;
                pckPosToGreenVer.SelectedIndex = -1;
            }
            else
            {
                grdOnGreen.IsVisible = false;
                grdOffGreen.IsVisible = true;
                pckPosOnGreenHorz.SelectedIndex = -1;
                pckPosOnGreenVer.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Saves the shot the user created and closes the modal
        /// </summary>
        public async void SaveShot()
        {
            await App.dataFactory.CreateShot(this.BindingContext as FairwayModel);
            ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
        }

        /// <summary>
        /// Deletes this shot (Only displayed if the shot has been created already (Id != 0))
        /// </summary>
        async void DeleteShot()
        {
            if (await DisplayAlert("Delete Approach", "Are you sure you want to delete this shot?", "Delete", "Cancel"))
            {
                App.dataFactory.DeleteShot(this.BindingContext as ShotModel);
                ShotDeleted?.Invoke(this.BindingContext, EventArgs.Empty);
            }
        }
    }
}