using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Geolocation
{
    public partial class MainPage : ContentPage
    {
        Xamarin.Essentials.Location location;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            location = await Xamarin.Essentials.Geolocation.GetLocationAsync(
                new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(2d))
                );

            locName.Text = $" Latitude: {location.Latitude}\n\n Longitute: {location.Longitude}\n\n Altitude: {location.Altitude}";

            stack.IsVisible = true;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (location != null)
            {
                await location.OpenMapsAsync();
            }
        }
    }
}
