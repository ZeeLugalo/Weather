using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Weather
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Data();
        }
        private async Task Data()
        {
            var data = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (data != PermissionStatus.Granted)
            {
                var newdata = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }
            var location = await Geolocation.GetLocationAsync();


            var latitude = location.Latitude;
            var longitude = location.Longitude;
           
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=6ff6b2a9acfdad848802351eeff10602");
            var weathersData = JsonConvert.DeserializeObject<OpenWeatherData>(response);
            BindingContext = weathersData;
          
        }
    }









}
