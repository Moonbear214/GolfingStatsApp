using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GolfingStats.Models.ShotModels;

namespace GolfingStats.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShotDetailsPage : ContentPage
	{
        ShotModel shotModel = new ShotModel();
		public ShotDetailsPage ()
		{
            this.BindingContext = shotModel;

			InitializeComponent ();
		}

        public void Save()
        {
            var asdf = this.BindingContext;
        }
	}
}