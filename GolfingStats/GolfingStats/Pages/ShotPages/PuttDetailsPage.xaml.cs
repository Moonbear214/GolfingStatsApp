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
	public partial class PuttDetailsPage : ContentPage
    {
        public event EventHandler ShotSaved;
        
        public PuttDetailsPage (int roundId, int holeId, int shotNum)
        {
            PuttModel puttModel = new PuttModel() { RoundId = roundId, HoleId = holeId, ShotNumber = shotNum };
            this.BindingContext = puttModel;

			InitializeComponent ();
            PageSetup();
		}

        public PuttDetailsPage (PuttModel puttModel)
        {
            this.BindingContext = puttModel;

            InitializeComponent();
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

        public async void SaveShot()
        {
            await App.dataFactory.CreateShot(this.BindingContext as PuttModel);

            ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
        }
        
    }
}