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
	public partial class AddHolesPage : CarouselPage
    {
        CourseModel courseModel;
        bool NewCourse = true;

        public AddHolesPage(CourseModel course, bool newCourse)
        {
            courseModel = course;

            InitializeComponent();

            Title = course.Name;

            this.ItemsSource = course.Holes;

            NewCourse = newCourse;
            PageSetup();
        }

        /// <summary>
        /// Method to setup extra UI for page
        /// </summary>
        private void PageSetup()
        {
            ToolbarItem tlbSave = new ToolbarItem()
            {
                Text = "Save"
            };
            tlbSave.Clicked += UpdateCourseCheck;

            ToolbarItem tlbDelete = new ToolbarItem()
            {
                Text = "Delete"
            };
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

        async void UpdateCourse()
        {
            courseModel.Holes = (List<HoleModel>)this.ItemsSource;
            await App.dataFactory.UpdateCourse(courseModel);
            await Navigation.PopAsync();
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
            }
        }

    }
}