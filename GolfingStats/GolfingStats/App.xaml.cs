using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using GolfingStats.Models;

namespace GolfingStats
{
	public partial class App : Application
	{
        public static GolfstatsRepository GolfstatsRepo { get; private set; }

		public App (string dbPath)
		{
			InitializeComponent();

            GolfstatsRepo = new GolfstatsRepository(dbPath);

            DummyData();

			MainPage = new NavigationPage(new GolfingStats.HomePage());
		}


        //Add dummy data to the local storage
        private async void DummyData()
        {
            RoundModel round1 = new RoundModel
            {
                Date = DateTime.Now.Date,
                GolfCourse = "Maccauvlei",
                Handicap = 7,
                RoundTotal = 74
            };

            RoundModel round2 = new RoundModel
            {
                Date = DateTime.Now.Date,
                GolfCourse = "Riviera",
                Handicap = 7,
                RoundTotal = 74
            };

            RoundModel round3 = new RoundModel
            {
                Date = DateTime.Now.Date,
                GolfCourse = "Serengetti",
                Handicap = 7,
                RoundTotal = 74
            };

            RoundModel round4 = new RoundModel
            {
                Date = DateTime.Now.Date,
                GolfCourse = "Eye of Africa",
                Handicap = 7,
                RoundTotal = 74
            };

            await GolfstatsRepo.AddNewRound(round1);
            await GolfstatsRepo.AddNewRound(round2);
            await GolfstatsRepo.AddNewRound(round3);
            await GolfstatsRepo.AddNewRound(round4);

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
