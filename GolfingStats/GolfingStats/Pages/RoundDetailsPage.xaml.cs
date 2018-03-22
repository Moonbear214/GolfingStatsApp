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

            UpdateCoursePicker();

            this.BindingContext = new RoundModel();
        }

        public RoundDetailsPage (RoundModel round)
		{
			InitializeComponent ();

            Title = round.CourseName;

            this.BindingContext = round;
        }


        public async void StartNewRound()
        {
            RoundModel round = (RoundModel)this.BindingContext;

            await Navigation.PushAsync(new Pages.HolesDetailsPage(round, selectedCourse));
        }


        private async void UpdateCoursePicker()
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