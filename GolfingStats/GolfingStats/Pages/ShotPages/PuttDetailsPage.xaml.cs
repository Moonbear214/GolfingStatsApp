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

            ShowPuttMissedObjects(false);
		}

        public PuttDetailsPage (PuttModel puttModel)
        {
            InitializeComponent();
        }

        public async void SaveShot()
        {
            await App.dataFactory.CreateShotFairway(this.BindingContext as FairwayModel);

            ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
        }

        private void toggledInHole(Switch @switch, EventArgs args)
        {
            ShowPuttMissedObjects (@switch.IsToggled);
        }

        private void ShowPuttMissedObjects(bool hide)
        {
            this.HoleMissedControls.IsVisible = hide;
        }
    }
}