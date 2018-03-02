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
	public partial class NewRoundPage : CarouselPage
    {
		public NewRoundPage ()
		{
            //------------------------------------------------------------------------
			InitializeComponent ();

            Title = "Hole";

            ItemsSource = HoleModel.EmptyRound;
        }

        public void Save()
        {
            var asdf = this.ItemsSource;
            
        }
	}
}