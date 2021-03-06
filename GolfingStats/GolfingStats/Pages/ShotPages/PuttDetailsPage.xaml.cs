﻿using System;
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
        public event EventHandler ShotDeleted;

        public PuttDetailsPage (int roundId, int holeId, int shotNum, ShotModel prevShotHit)
        {
            PuttModel puttModel = new PuttModel() { RoundId = roundId, HoleId = holeId, ShotNumber = shotNum, DistanceToHole = prevShotHit.DistanceLeftToHole };
            this.BindingContext = puttModel;

			InitializeComponent ();
            PageSetup();
		}

        public PuttDetailsPage (PuttModel puttModel)
        {
            this.BindingContext = puttModel;

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
        /// The user changed where they are aiming the putt.
        /// If not center, display aiming distance
        /// </summary>
        private void AimingChanged(object sender, EventArgs args)
        {
            if (((Picker)sender).SelectedItem.ToString() == "Center")
                grdAimingDistance.IsVisible = false;
            else
                grdAimingDistance.IsVisible = true;
        }

        /// <summary>
        /// Saves the shot the user created and closes the modal
        /// </summary>
        public async void SaveShot()
        {
            await App.dataFactory.CreateShot(this.BindingContext as PuttModel);
            ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
        }

        /// <summary>
        /// Deletes this shot (Only displayed if the shot has been created already (Id != 0))
        /// </summary>
        async void DeleteShot()
        {
            if (await DisplayAlert("Delete Putt", "Are you sure you want to delete this shot?", "Delete", "Cancel"))
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