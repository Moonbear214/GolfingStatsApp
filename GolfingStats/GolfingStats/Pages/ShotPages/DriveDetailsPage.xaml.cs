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
	public partial class DriveDetailsPage : ContentPage
	{
        public event EventHandler ShotSaved;

		public DriveDetailsPage (int roundId, int holeId, int shotNum)
		{
            DriveModel driveModel = new DriveModel() { RoundId = roundId, HoleId = holeId, ShotNumber = shotNum };
            this.BindingContext = driveModel;

			InitializeComponent ();
            PageSetup();
        }

        public DriveDetailsPage (DriveModel drive)
        {
            this.BindingContext = drive;

            InitializeComponent();
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
            if (swcOnFairway.IsToggled)
                grdPosToFairwayHorz.IsVisible = false;
            else
                grdPosOnFairwayHorz.IsVisible = false;

            swcOnFairway.Toggled += SwcOnFairway_Toggled;
            //===========================================================
        }

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

        private void SwcOnFairway_Toggled(object sender, ToggledEventArgs e)
        {
            if (((Switch)sender).IsToggled)
            {
                grdPosOnFairwayHorz.IsVisible = true;
                grdPosToFairwayHorz.IsVisible = false;
                pckPosToFairwayHorz.SelectedIndex = -1;
            }
            else
            {
                grdPosToFairwayHorz.IsVisible = true;
                grdPosOnFairwayHorz.IsVisible = false;
                pckPosOnFairwayHorz.SelectedIndex = -1;
            }
        }


        async void SaveShot()
        {
            await App.dataFactory.CreateShot(this.BindingContext as DriveModel);

            ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
        }

    }
}