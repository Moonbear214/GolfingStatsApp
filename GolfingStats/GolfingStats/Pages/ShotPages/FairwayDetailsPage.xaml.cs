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

        public FairwayDetailsPage (int roundId, int holeId, int shotNum)
        {
            FairwayModel fairwayModel = new FairwayModel() { RoundId = roundId, HoleId = holeId, ShotNumber = shotNum };
            this.BindingContext = fairwayModel;

			InitializeComponent ();
		}

        public FairwayDetailsPage (FairwayModel fairwayModel)
        {
            InitializeComponent();
        }

        public async void SaveShot()
        {
            await App.dataFactory.CreateShotFairway(this.BindingContext as FairwayModel);

            ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
        }
    }
}