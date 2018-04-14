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
	public partial class DropShotDetailsPage : ContentPage
    {
        public event EventHandler ShotSaved;
        public event EventHandler ShotDeleted;

        public DropShotDetailsPage (int roundId, int holeId, int shotNum)
		{
            DropShotModel dropShotModel = new DropShotModel() { RoundId = roundId, HoleId = holeId, ShotNumber = shotNum };
            this.BindingContext = dropShotModel;

			InitializeComponent ();
		}

        public DropShotDetailsPage(DropShotModel dropShot)
        {
            this.BindingContext = dropShot;

            InitializeComponent();
            btnDeleteShot.IsVisible = true;
        }

        /// <summary>
        /// Saves the shot the user created and closes the modal
        /// </summary>
        async void SaveShot()
        {
            if (string.IsNullOrEmpty(((ShotModel)this.BindingContext).Club))
                await DisplayAlert("Club", "Please select the club that was used.", "Okay");
            else
            {
                await App.dataFactory.CreateShot(this.BindingContext as DropShotModel);
                ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Deletes this shot (Only displayed if the shot has been created already (Id != 0))
        /// </summary>
        async void DeleteShot()
        {
            if (await DisplayAlert("Delete Tee Shot", "Are you sure you want to delete this shot?", "Delete", "Cancel"))
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