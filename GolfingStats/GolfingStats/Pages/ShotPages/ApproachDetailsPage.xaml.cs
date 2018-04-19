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
    public partial class ApproachDetailsPage : ContentPage
    {
        public event EventHandler ShotSaved;
        public event EventHandler ShotDeleted;

        public ApproachDetailsPage(int roundId, int holeId, int shotNum, ShotModel PrevShotHit)
        {
            ApproachModel approachModel = new ApproachModel()
            {
                RoundId = roundId,
                HoleId = holeId,
                ShotNumber = shotNum,
                DistanceToHole = PrevShotHit.DistanceLeftToHole
            };

            if (PrevShotHit.GetType() == typeof(DriveModel))
            {
                approachModel.BallLie = (((DriveModel)PrevShotHit).OnFairway == true) ? "Fairway" : "Ruff";
                if (!string.IsNullOrEmpty(((DriveModel)PrevShotHit).PosOnFairwayHorz))
                approachModel.BallPositionSide = ((DriveModel)PrevShotHit).PosOnFairwayHorz;
                else
                    approachModel.BallPositionSide = ((DriveModel)PrevShotHit).PosToFairwayHorz;
            }

            this.BindingContext = approachModel;

            InitializeComponent();
            PageSetup();
        }

        public ApproachDetailsPage(ApproachModel approachModel)
        {
            this.BindingContext = approachModel;

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

            //On/Off Green 
            //===========================================================
            if (swcLayup.IsToggled)
                grdGreenControls.IsVisible = false;

            swcLayup.Toggled += SwcLayup_Toggled;
            //===========================================================

            //On/Off Green 
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
        /// Displays or hides the onGreen switch and pos on/to green controls deppending on what the user chose
        /// </summary>
        private void SwcLayup_Toggled(object sender, ToggledEventArgs e)
        {
            if (((Switch)sender).IsToggled)
            {
                grdGreenControls.IsVisible = false;
                swcOnGreen.IsToggled = false;
                pckPosToGreenHorz.SelectedIndex = -1;
                pckPosToGreenVer.SelectedIndex = -1;
            }
            else
            {
                grdGreenControls.IsVisible = true;
            }
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
            if (string.IsNullOrEmpty(((ShotModel)this.BindingContext).Club))
                await DisplayAlert("Club", "Please select the club that was used.", "Okay");
            else
            {
                await App.dataFactory.CreateShot(this.BindingContext as ApproachModel);
                ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
            }
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

        /// <summary>
        /// Changes the text of the entry to "" if the text is 0 (Which is default)
        /// Help speed up pace of entering information
        /// </summary>
        private void EntryFocus(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Entry)sender).Text) || ((Entry)sender).Text == "0")
                ((Entry)sender).Text = "";
        }

        /// <summary>
        /// Changes the text of the entry to 0 if the text is ""
        /// </summary>
        private void EntryUnfocus(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Entry)sender).Text))
                ((Entry)sender).Text = "0";
        }
    }
}