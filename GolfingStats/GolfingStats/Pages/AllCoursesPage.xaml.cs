using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GolfingStats.Models;

namespace GolfingStats.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllCoursesPage : ContentPage
    {
        public AllCoursesPage()
        {
            Title = "All Courses";
            InitializeComponent();

            PageSetup();
        }

        /// <summary>
        /// Method to setup extra UI for page
        /// </summary>
        async void PageSetup()
        {
            lwAllCourses.ItemsSource = await App.dataFactory.GetAllCourses();
            lwAllCourses.IsRefreshing = false;
        }

        /// <summary>
        /// Shows modal with entry box to add course name then,
        /// takes the user to add to a page to add a new course
        /// </summary>
        public void AddCourseTapped()
        {
            CourseNameOverlay.IsVisible = true;
        }

        public async void SaveAndCreateCourse(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entCourseName.Text))
            {
                await DisplayAlert("No Course Name", "Add a name for the course before saving.", "Okay");
            }
            else
            {
                CourseModel course = await App.dataFactory.CreateNewCourse(entCourseName.Text);
                await Navigation.PushAsync(new Pages.AddHolesPage(course, true), true);
                CancelCourseName();
            }
        }

        /// <summary>
        /// Takes the user to a page to view/edit the couse they created
        /// </summary>
        async void OnCourseTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddHolesPage(((ListView)sender).SelectedItem as CourseModel, false));
            lwAllCourses.SelectedItem = null;
        }

        void CancelCourseName()
        {
            CourseNameOverlay.IsVisible = false;
            entCourseName.Text = "";
        }

        protected override bool OnBackButtonPressed()
        {
            CancelCourseName();
            return true;
        }
    }
}