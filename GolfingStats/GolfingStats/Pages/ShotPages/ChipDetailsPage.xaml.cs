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
	public partial class ChipDetailsPage : ContentPage
    {
        public event EventHandler ShotSaved;
        public event EventHandler ShotDeleted;

        public ChipDetailsPage (int roundId, int holeId, int shotNum)
        {
            ChipModel chipModel = new ChipModel() { RoundId = roundId, HoleId = holeId, ShotNumber = shotNum };
            this.BindingContext = chipModel;

			InitializeComponent ();
            PageSetup();
        }

        public ChipDetailsPage (ChipModel chipModel)
        {
            this.BindingContext = chipModel;

            InitializeComponent();
            btnDeleteShot.IsVisible = true;
            PageSetup();
        }

        /// <summary>
        /// Setup the visual elements of the page (Hide objects that aren't necessary, setup click events ect.)
        /// </summary>
        void PageSetup()
        {
            //In/Missed Hole
            //===========================================================
            if (swcInHole.IsToggled)
                grdHoleMissed.IsVisible = false;
            else
                grdHoleMissed.IsVisible = true;

            swcInHole.Toggled += SwcInHole_Toggled;
            //===========================================================
        }

        /// <summary>
        /// Hides after shot values no neccesary if ball is in hte hole
        /// </summary>
        private void SwcInHole_Toggled(object sender, ToggledEventArgs e)
        {
            if (((Switch)sender).IsToggled)
            {
                grdHoleMissed.IsVisible = false;
                entDistanceLeft.Text = "0";
                pckPosToHoleHorz.SelectedIndex = -1;
                pckPosToHoleVer.SelectedIndex = -1;
            }
            else
            {
                grdHoleMissed.IsVisible = true;
            }
        }

        /// <summary>
        /// Saves the shot the user created and closes the modal
        /// </summary>
        async void SaveShot()
        {
            await App.dataFactory.CreateShot(this.BindingContext as ChipModel);
            ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
        }

        /// <summary>
        /// Deletes this shot (Only displayed if the shot has been created already (Id != 0))
        /// </summary>
        async void DeleteShot()
        {
            if (await DisplayAlert("Delete Chip", "Are you sure you want to delete this shot?", "Delete", "Cancel"))
            {
                App.dataFactory.DeleteShot(this.BindingContext as ShotModel);
                ShotDeleted?.Invoke(this.BindingContext, EventArgs.Empty);
            }
        }
    }
}