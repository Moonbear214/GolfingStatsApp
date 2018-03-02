﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GolfingStats.Models;

namespace GolfingStats.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoundDetailsPage : CarouselPage
    {
		public RoundDetailsPage ()
		{
            //------------------------------------------------------------------------
			InitializeComponent ();

            Title = "Hole";

            ItemsSource = HoleModel.EmptyRound;
        }

        public void Save()
        {
            var asdf = this.ItemsSource;
            
        }

        public void AddShot()
        {
            Navigation.PushModalAsync(new ShotDetailsPage(), true);
        }
	}
}