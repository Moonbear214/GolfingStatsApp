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
	public partial class DriveDetailsPage : ContentPage
	{
        public event EventHandler ShotSaved;
        public event EventHandler ShotDeleted;

        public DriveDetailsPage (int roundId, int holeId, int shotNum, int disToHole)
		{
            DriveModel driveModel = new DriveModel() { RoundId = roundId, HoleId = holeId, ShotNumber = shotNum, DistanceToHole = disToHole };
            this.BindingContext = driveModel;

			InitializeComponent ();
            PageSetup();
        }

        public DriveDetailsPage (DriveModel drive)
        {
            this.BindingContext = drive;

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

            //On/Off Fairway 
            //===========================================================
            if (swcOnFairway.IsToggled)
                grdPosToFairwayHorz.IsVisible = false;
            else
                grdPosOnFairwayHorz.IsVisible = false;

            swcOnFairway.Toggled += SwcOnFairway_Toggled;
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
        /// Displays either on fairway values or off fairway values deppending on what the user chose
        /// </summary>
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

        /// <summary>
        /// Saves the shot the user created and closes the modal
        /// </summary>
        async void SaveShot()
        {
            await App.dataFactory.CreateShot(this.BindingContext as DriveModel);
            ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
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

        async void CloseModal()
        {
            await Navigation.PopModalAsync(true);
        }

        private void EntryFocus(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Entry)sender).Text) || ((Entry)sender).Text == "0")
                ((Entry)sender).Text = "";
        }

        private void EntryUnfocus(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Entry)sender).Text))
                ((Entry)sender).Text = "0";
        }
    }
}