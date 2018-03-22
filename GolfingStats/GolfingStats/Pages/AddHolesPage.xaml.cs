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

		public AddHolesPage(CourseModel course)
        {
            courseModel = course;

            InitializeComponent ();
            
            Title = course.Name;

            this.ItemsSource = course.Holes;
        }

        public async void Save()
        {
            courseModel.Holes = (List<HoleModel>)this.ItemsSource;

            await App.dataFactory.UpdateCourse(courseModel);

            await Navigation.PopAsync();
        }

    }
}