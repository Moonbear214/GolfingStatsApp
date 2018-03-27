using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GolfingStats.Models;
using GolfingStats.Models.ShotModels;
using GolfingStats.Pages.ShotPages;

namespace GolfingStats.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HolesDetailsPage : CarouselPage
    {
        AllShotsModel allShots = new AllShotsModel();

        public HolesDetailsPage(RoundModel round, CourseModel course)
        {
            InitializeComponent();

            Title = course.Name;

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
            //===================================================
            //IList<ShotModel> qwer = new List<ShotModel>();

            //ShotModel asdf = new ShotModel() { Club = "Driver" };
            //ShotModel asdf1 = new ShotModel() { Club = "Driver1" };
            //ShotModel asdf2 = new ShotModel() { Club = "Driver2" };
            //ShotModel asdf3 = new ShotModel() { Club = "Driver3" };
            //ShotModel asdf4 = new ShotModel() { Club = "Driver4" };

            //qwer.Add(asdf);
            //qwer.Add(asdf1);
            //qwer.Add(asdf2);
            //qwer.Add(asdf3);
            //qwer.Add(asdf4);

            //holes[0].ShotsPlayedList = qwer;
            //===================================================

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

            }
            else if (picker.SelectedIndex == 1 || (picker.SelectedIndex == 0 && par == 3))
            {
                FairwayDetailsPage fairwayDetailsPage = new FairwayDetailsPage(roundId, holeId, shotNum);

                fairwayDetailsPage.ShotSaved += ShotSaved;

                Navigation.PushModalAsync(fairwayDetailsPage);

            }
            else if (picker.SelectedIndex == 2)
            {
                ChipDetailsPage chipDetailsPage = new ChipDetailsPage(roundId, holeId, shotNum);

                chipDetailsPage.ShotSaved += ShotSaved;

                Navigation.PushModalAsync(chipDetailsPage);

            }
            else if (picker.SelectedIndex == 3)
            {
                PuttDetailsPage puttDetailsPage = new PuttDetailsPage(roundId, holeId, shotNum);

                puttDetailsPage.ShotSaved += ShotSaved;

                Navigation.PushModalAsync(puttDetailsPage);
            }
        }


        private async void ShotSaved(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync(true);

            //============Test==============================
            List<ShotModel> displayShots = new List<ShotModel>();

            if (sender.GetType() == typeof(DriveModel))
            {
                var ShotPlayed = (DriveModel)sender;
                //allShots.DriveASModel.Add(ShotPlayed);
            }
            else if (sender.GetType() == typeof(FairwayModel))
            {
                var ShotPlayed = (FairwayModel)sender;
                //allShots.FairwayASModel.Add(ShotPlayed);
            }
            else if (sender.GetType() == typeof(ChipModel))
            {
                var ShotPlayed = (ChipModel)sender;
                //allShots.ChipASModel.Add(ShotPlayed);
            }
            else if (sender.GetType() == typeof(PuttModel))
            {
                var ShotPlayed = (PuttModel)sender;
                //allShots.PuttASModel.Add(ShotPlayed);
            }


            HoleModel HolePage = (HoleModel)this.SelectedItem;

            HolePage.ShotsPlayedList.Add((ShotModel)sender);
            //HolePage.ShotsPlayedList.Add((ShotModel)sender);
            //HolePage.ShotsPlayedList.Add((ShotModel)sender);
            //HolePage.ShotsPlayedList.Add((ShotModel)sender);

            ListView lwShotsPlayed = this.CurrentPage.FindByName<ListView>("lwShotsPlayed");
            lwShotsPlayed.ItemsSource = HolePage.ShotsPlayedList;

            this.SelectedItem = HolePage;
            //============Test==============================
        }

        void OnShotTapped(object sender, EventArgs args)
        {

        }
    }
}