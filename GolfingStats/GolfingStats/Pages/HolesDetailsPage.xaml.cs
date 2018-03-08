using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GolfingStats.Models;
using GolfingStats.Factories;

namespace GolfingStats.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HolesDetailsPage : CarouselPage
    {
		public HolesDetailsPage (RoundModel round)
        {
            InitializeComponent ();

            Title = "Hole";

            if (round.Id == 0)
            {
                CreateNewRound(round);
            }
            else
            {

            }
        }

        public async void CreateNewRound(RoundModel round)
        {
            this.ItemsSource = await App.dataFactory.CreateFullRound(round);
        }

        public void Save()
        {

        }

        public void AddShot()
        {
            var holeNumber = this.ItemsSource;

            Navigation.PushModalAsync(new ShotDetailsPage(), true);
        }
    }
}