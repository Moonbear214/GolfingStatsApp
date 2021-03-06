﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using GolfingStats.Factories;

namespace GolfingStats
{
	public partial class App : Application
	{
        // Creates a static datafactory here that can be referenced through entire app.
        // App.dataFactory...
        public static DataFactory dataFactory;

		public App (string dbPath)
		{
			InitializeComponent();

            dataFactory = new DataFactory(dbPath);
            
			this.MainPage = new NavigationPage(new HomePage());
		}

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
