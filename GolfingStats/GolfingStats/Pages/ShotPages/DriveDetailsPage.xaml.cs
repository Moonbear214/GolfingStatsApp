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
		}

        public DriveDetailsPage (DriveModel drive)
        {
            this.BindingContext = drive;

            InitializeComponent();
        }

        public async void SaveShot()
        {
            await App.dataFactory.CreateShotDrive(this.BindingContext as DriveModel);

            ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
        }

    }
}