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
        Entry entCourseName = new Entry
        {
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Placeholder = "..."
        };

        Button btnSaveCourseName = new Button()
        {
            VerticalOptions = LayoutOptions.End,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            BackgroundColor = Color.AliceBlue,
            Text = "Create Course"
        };

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

            btnSaveCourseName.Clicked += SaveAndCreateCourse;
        }

        /// <summary>
        /// Shows modal with entry box to add course name then,
        /// takes the user to add to a page to add a new course
        /// </summary>
        public async void AddCourseTapped()
        {
            ContentPage courseName = new ContentPage()
            {
                Title = "AddCourse",
                Content =
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Children =
                        {
                            new StackLayout
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                VerticalOptions = LayoutOptions.CenterAndExpand,
                                Children =
                                {
                                    new Label
                                    {
                                        VerticalOptions = LayoutOptions.CenterAndExpand,
                                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                                        Text = "Course Name:"
                                    },
                                    entCourseName,
                                    btnSaveCourseName
                                }
                            }
                        }
                    }
            };

            await Navigation.PushModalAsync(courseName, true);
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

                await Navigation.PopModalAsync(true);
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
    }
}