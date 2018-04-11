using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GolfingStats.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShotModalNavBar : StackLayout
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ShotModalNavBar), default(string), Xamarin.Forms.BindingMode.OneWay);
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }

            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public ShotModalNavBar()
        {
            InitializeComponent();

            lblHoleNumber.Text = string.Format("Shot number: {0}", Title);
            btnCloseModal.Clicked += BtnCloseModal_Clicked;
        }

        private async void BtnCloseModal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TitleProperty.PropertyName)
            {
                lblHoleNumber.Text = string.Format("Shot number: {0}", Title);
            }
        }
    }
}