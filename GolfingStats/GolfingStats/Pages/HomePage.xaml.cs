using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GolfingStats.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GolfingStats
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
    {
        public HomePage ()
		{
            this.Title = "All Rounds";

			InitializeComponent ();
		}

        public async void NavNewRound()
        {
            await Navigation.PushAsync(new Pages.NewRoundPage(), true);
        }

        //public async void OnNewButtonClicked(object sender, EventArgs args)
        //{
        //    statusMessage.Text = "";

        //    await App.PersonRepo.AddNewPersonAsync(newPerson.Text);
        //    statusMessage.Text = App.PersonRepo.StatusMessage;
        //}

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<RoundModel> Rounds = await App.GolfstatsRepo.GetAllRounds();
            RoundList.ItemsSource = Rounds;
        }
    }
}