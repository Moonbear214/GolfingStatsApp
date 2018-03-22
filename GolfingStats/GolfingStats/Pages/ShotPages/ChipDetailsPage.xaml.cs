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

        public ChipDetailsPage (int roundId, int holeId, int shotNum)
        {
            ChipModel chipModel = new ChipModel() { RoundId = roundId, HoleId = holeId, ShotNumber = shotNum };
            this.BindingContext = chipModel;

			InitializeComponent ();
		}

        public ChipDetailsPage (ChipModel chipShotModel)
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