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
	public partial class RoundDetailsPage : ContentPage
    {
        public RoundDetailsPage()
        {
            InitializeComponent();

            Title = "New Round";

            this.BindingContext = new RoundModel();
        }

        public RoundDetailsPage (RoundModel round)
		{
            //if (round.Id == 0)
            //{
            //    RoundModel roundModel = DataFactory.CreateNewRound();
            //}

            //========================================================
			InitializeComponent ();

            Title = round.GolfCourse;

            this.BindingContext = round;
        }

        public async void StartNewRound()
        {
            RoundModel round = (RoundModel)this.BindingContext;

            await Navigation.PushAsync(new Pages.HolesDetailsPage(round));
        }
    }
}