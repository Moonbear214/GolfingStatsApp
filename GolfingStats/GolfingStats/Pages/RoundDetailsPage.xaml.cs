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
        private CourseModel selectedCourse;

        public RoundDetailsPage()
        {
            InitializeComponent();

            Title = "New Round";
            tlbGoToHole.Text = "Start Round";
            tlbGoToHole.Clicked += StartNewRound;
            stkCourseDisplay.IsVisible = false;

            UpdateCoursePicker();

            this.BindingContext = new RoundModel();
        }

        public RoundDetailsPage (RoundModel round)
		{
			InitializeComponent ();

            Title = round.CourseName;
            tlbGoToHole.Text = "View Round";
            tlbGoToHole.Clicked += ViewRound;
            stkCoursePick.IsVisible = false;

            this.BindingContext = round;
        }


        async void StartNewRound(object sender, EventArgs args)
        {
            RoundModel round = (RoundModel)this.BindingContext;
            round.CourseName = selectedCourse.Name;
            await Navigation.PushAsync(new Pages.HolesDetailsPage(round, selectedCourse));
        }

        async void ViewRound(object sender, EventArgs args)
        {
            RoundModel round = (RoundModel)this.BindingContext;
            await Navigation.PushAsync(new Pages.HolesDetailsPage(round));
        }

        async void UpdateCoursePicker()
        {
            CoursePicker.ItemsSource = await App.dataFactory.GetAllCourses();
            CoursePicker.ItemDisplayBinding = new Binding("Name");
        }


        void CourseSelected(Picker sender, EventArgs args)
        {
            selectedCourse = (CourseModel)sender.SelectedItem;
        }
    }
}