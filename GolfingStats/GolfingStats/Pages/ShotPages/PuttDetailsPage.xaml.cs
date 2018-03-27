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
        
        public PuttDetailsPage (int roundId, int holeId, int shotNum)
        {
            PuttModel puttModel = new PuttModel() { RoundId = roundId, HoleId = holeId, ShotNumber = shotNum };
            this.BindingContext = puttModel;

			InitializeComponent ();

            ShowPuttMissedObjects(false);
		}

        public PuttDetailsPage (PuttModel puttModel)
        {
            this.BindingContext = puttModel;

            InitializeComponent();
        }

        public async void SaveShot()
        {
            await App.dataFactory.CreateShot(this.BindingContext as PuttModel);

            ShotSaved?.Invoke(this.BindingContext, EventArgs.Empty);
        }

        private void ToggledInHole(Switch sender, EventArgs args)
        {
            ShowPuttMissedObjects (sender.IsToggled);
        }

        private void ShowPuttMissedObjects(bool hide)
        {
            this.HoleMissedControls.IsVisible = hide;
        }
    }
}