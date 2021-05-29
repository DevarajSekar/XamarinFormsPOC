using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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


            lat.Text = location.Latitude.ToString();
            longi.Text = location.Longitude.ToString();
            alt.Text = location.Altitude.ToString();

            var result = await Geocoding.GetPlacemarksAsync(location);
            if (result != null)
            {
                string address = $"{result.FirstOrDefault()?.FeatureName}," +
                    $"{result.FirstOrDefault()?.SubThoroughfare}," +
                    $"{ result.FirstOrDefault()?.Thoroughfare}," +
                    $"{ result.FirstOrDefault()?.SubLocality}," +
                    $"{ result.FirstOrDefault()?.Locality}," +
                    $"{ result.FirstOrDefault()?.AdminArea}," +
                    $"{ result.FirstOrDefault()?.PostalCode}," +
                    $"{ result.FirstOrDefault()?.CountryName}";

                loc.Text = address;
            }

            //locName.Text = $" Latitude: {location.Latitude}\n\n Longitute: {location.Longitude}\n\n Altitude: {location.Altitude}";

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
