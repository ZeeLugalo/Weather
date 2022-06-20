using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = new NavigationPage(new WeatherView());
            page.BarTextColor = Color.Black;
            page.BarBackgroundColor = Color.LightSkyBlue;

            MainPage= page;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
