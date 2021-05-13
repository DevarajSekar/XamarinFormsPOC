using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace UnitConverter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            label.Text = UnitConverters.CelsiusToFahrenheit(Convert.ToDouble(entry.Text)).ToString();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            label.Text = UnitConverters.KilometersToMiles(Convert.ToDouble(entry.Text)).ToString();
        }
    }
}
