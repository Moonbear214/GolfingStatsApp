using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GolfingStats.Models;
using GolfingStats.Factories;
using Acr.UserDialogs;

namespace GolfingStats.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoundDetailsPage : ContentPage
    {
        private CourseModel selectedCourse;

        /// <summary>
        /// Enters when player is about to start new round
        /// </summary>
        public RoundDetailsPage()
        {
            var asdf = this.Navigation.NavigationStack;
            InitializeComponent();

            Title = "New Round";
            tlbGoToHole.Text = "Start Round";
            tlbGoToHole.Clicked += StartNewRound;
            dpDatePlayed.MaximumDate = DateTime.Now;

            UpdateCoursePicker();

            this.BindingContext = new RoundModel();
        }

        /// <summary>
        /// Enters when old round is passed to this page
        /// </summary>
        /// <param name="round"></param>
        public RoundDetailsPage (RoundModel round)
		{
			InitializeComponent ();

            Title = round.CourseName;
            tlbGoToHole.Text = "View";
            tlbGoToHole.Clicked += ViewRound;
            grdNewCourse.IsVisible = false;
            stkRoundStats.IsVisible = true;

            ToolbarItem deleteToolbarItem = new ToolbarItem()
            {
                Text = "Delete"
            };
            deleteToolbarItem.Clicked += DeleteRound;
            ToolbarItems.Add(deleteToolbarItem);

            if (round.ReloadStats)
                ReloadRound(round);
            else
                this.BindingContext = round;
        }

        async void ReloadRound(RoundModel round)
        {
            using (UserDialogs.Instance.Loading("Calculating Statistics", null, null, true, MaskType.Black))
                this.BindingContext = await App.dataFactory.UpdateRound(round);
        }

        /// <summary>
        /// New round is created and saved. Player is taken to page to add shots for each hole
        /// </summary>
        private async void StartNewRound(object sender, EventArgs args)
        {
            if (selectedCourse == null)
            {
                await DisplayAlert("Course", "Please select the course you want to play first.", "Okay");
            }
            else
            {
                RoundModel round = (RoundModel)this.BindingContext;
                round.CourseName = selectedCourse.Name;
                await Navigation.PushAsync(new Pages.RoundHolesPage(round, selectedCourse));
            }
        }

        /// <summary>
        /// Player wants to view the holes and shots that was played on a previous round
        /// </summary>
        private async void ViewRound(object sender, EventArgs args)
        {
            RoundModel round = (RoundModel)this.BindingContext;
            await Navigation.PushAsync(new Pages.RoundHolesPage(round));
        }

        /// <summary>
        /// Player wants to delete round that he has played
        /// </summary>
        private async void DeleteRound(object sender, EventArgs e)
        {
            if (await DisplayAlert(string.Format("Delete {0}", Title), "Are you sure you want to delete this round?", "Delete", "Cancel"))
            {
                App.dataFactory.DeleteRoundHolesShots((RoundModel)this.BindingContext);
                await Navigation.PopToRootAsync();
                DependencyService.Get<IMessage>().ShortAlert("Round deleted");
            }
        }

        /// <summary>
        /// Loads all courses from local storage and displays them in the course picker
        /// </summary>
        private async void UpdateCoursePicker()
        {
            List<CourseModel> AllCourses = await App.dataFactory.GetAllCourses();
            if (AllCourses.Count == 0)
            {
                AllCourses.Add(new CourseModel() { Name = "Please add a course from the homescreen." });
                CoursePicker.SelectedIndexChanged += (sender, e) => CoursePicker.SelectedIndex = -1;
            }
            CoursePicker.ItemsSource = AllCourses;
            CoursePicker.ItemDisplayBinding = new Binding("Name");
        }

        /// <summary>
        /// Player has tapped on a course to play
        /// </summary>
        private void CourseSelected(Picker sender, EventArgs args)
        {
            selectedCourse = (CourseModel)sender.SelectedItem;
        }
    }
}