using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Preference
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            entry.Text = Preferences.Get("entry", string.Empty);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("entry", entry.Text);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Preferences.Clear();
        }
    }
}
