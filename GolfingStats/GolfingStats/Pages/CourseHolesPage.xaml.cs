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
	public partial class CourseHolesPage : CarouselPage
    {
        CourseModel courseModel;
        bool NewCourse = true;

        ToolbarItem tlbSave = new ToolbarItem()
        {
            Text = "Save"
        };

        ToolbarItem tlbDelete = new ToolbarItem()
        {
            Text = "Delete"
        };


        public CourseHolesPage(CourseModel course, bool newCourse)
        {
            courseModel = course;

            InitializeComponent();

            Title = course.Name;

            this.ItemsSource = course.Holes;
            
            NewCourse = newCourse;
            this.Appearing += PageSetup;
        }

        /// <summary>
        /// Method to setup extra UI for page
        /// (Has to run when page appears, else buttons are only added when user swipes for the first time)
        /// </summary>
        private void PageSetup(object sender, EventArgs e)
        {
            tlbSave.Clicked += UpdateCourseCheck;
            tlbDelete.Clicked += DeleteCourse;

            if (!NewCourse)
                ToolbarItems.Add(tlbDelete);
            ToolbarItems.Add(tlbSave);
        }

        /// <summary>
        /// Displays and alert if the user is updating an old course that was created else,
        /// saves the course immediately.
        /// </summary>
        async void UpdateCourseCheck(object sender, EventArgs args)
        {
            if (!NewCourse)
            {
                if (await DisplayAlert(string.Format("Update {0}", Title), "Are you sure you want to update this course?", "Update", "Cancel"))
                {
                    UpdateCourse();
                }
            } else
            {
                UpdateCourse();
            }
        }

        /// <summary>
        /// Updates/Saves the course in local storage and takes user back to home page
        /// </summary>
        async void UpdateCourse()
        {
            courseModel.Holes = (List<HoleModel>)this.ItemsSource;
            await App.dataFactory.UpdateCourse(courseModel);
            await Navigation.PopToRootAsync();
            DependencyService.Get<IMessage>().ShortAlert("Course saved");
        }

        /// <summary>
        /// Checks if the user wants to delete the course and deletes it if true
        /// </summary>
        async void DeleteCourse(object sender, EventArgs args)
        {
            if (await DisplayAlert(string.Format("Delete {0}", Title), "Are you sure you want to delete this course?", "Delete", "Cancel"))
            {
                App.dataFactory.DeleteCourseAndHoles(courseModel);
                await Navigation.PopToRootAsync(true);
                DependencyService.Get<IMessage>().ShortAlert("Course deleted");
            }
        }

        /// <summary>
        /// Changes the text of the entry to "" if the text is 0 (Which is default)
        /// Help speed up pace of entering information
        /// </summary>
        private void EntryFocus(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Entry)sender).Text) || ((Entry)sender).Text == "0")
                ((Entry)sender).Text = "";
        }

        /// <summary>
        /// Changes the text of the entry to 0 if the text is ""
        /// </summary>
        private void EntryUnfocus(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Entry)sender).Text))
                ((Entry)sender).Text = "0";
        }
    }
}