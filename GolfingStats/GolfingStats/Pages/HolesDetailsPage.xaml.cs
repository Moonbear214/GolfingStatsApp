using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GolfingStats.Models;
using GolfingStats.Pages.ShotPages;

namespace GolfingStats.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HolesDetailsPage : CarouselPage
    {
		public HolesDetailsPage (RoundModel round, CourseModel course)
        {
            InitializeComponent ();
            
            Title = "Hole";

            if (round.Id == 0)
            {
                CreateNewRound(round, course.Holes);
            }
            else
            {

            }
        }
        
        public void Save()
        {

        }

        public async void CreateNewRound(RoundModel round, List<HoleModel> holes)
        {
            this.ItemsSource = await App.dataFactory.CreateNewFullRound(round, holes);
        }


        /// <summary>
        /// Is called when the user taps on the add shot button.
        /// The code will check which shot type was selected and navigate the user
        /// to the corresponding page to add that type of shot.
        /// </summary>
        private void AddShot(object sender, EventArgs args)
        {
            Picker picker = (Picker)sender;
            HoleModel holeModel = (HoleModel)this.SelectedItem;

            int holeId = holeModel.Id;
            int roundId = holeModel.RoundId;
            int shotNum = holeModel.ShotsPlayed + 1; //Lets the page know what number shot is being hit
            int par = holeModel.Par;

            if (picker.SelectedIndex == 0 && par != 3)
            {
                DriveDetailsPage driveDetailsPage = new DriveDetailsPage(roundId, holeId, shotNum);

                driveDetailsPage.ShotSaved += ShotSaved;

                Navigation.PushModalAsync(driveDetailsPage);


            } else if (picker.SelectedIndex == 1 || (picker.SelectedIndex == 0 && par == 3))
            {
                Navigation.PushModalAsync(new FairwayDetailsPage(roundId, holeId, shotNum));

            } else if (picker.SelectedIndex == 2)
            {
                Navigation.PushModalAsync(new ChipDetailsPage(roundId, holeId, shotNum));

            } else if (picker.SelectedIndex == 3)
            {
                Navigation.PushModalAsync(new PuttDetailsPage(roundId, holeId, shotNum));
            }

        }


        private async void ShotSaved(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync(true);

            var asdf = "Fuck Yeah!";
        }
    }
}