using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Buttons
{
    public partial class MainPage : ContentPage
    {
        private Theme theme;
        
        public MainPage()
        {
            InitializeComponent();
            theme = Theme.Light;
            centerbutton.Source = "light.png";
        }

        public Theme Theme
        {
            get
            {
                return theme;
            }
            set
            {
                theme = value;
                SetTheme();
                SetAnimation();
            }
        }



        private void SetTheme()
        {
            switch (Theme)
            {
                case Theme.Dark:
                    BackgroundColor = Color.FromHex("#121010");
                    //centerFrame.BackgroundColor = Color.Black;
                    centerFrame.BackgroundColor = Color.FromHex("#333131");
                    break;
                default:
                    BackgroundColor = Color.White;
                    centerFrame.BackgroundColor = Color.FromHex("#f2f2f2");
                    break;
            }
        }

        private async void SetAnimation()
        {
            uint transitionTime = 400;
            double displacement = centerbutton.Width;

            await Task.WhenAll(
                centerbutton.FadeTo(0, transitionTime, Easing.Linear),
                centerbutton.TranslateTo(-displacement, -centerbutton.Y - 15, transitionTime, Easing.Linear));

            switch (Theme)
            {
                case Theme.Dark:
                    centerbutton.Source = "dark2.jpg";
                    break;
                default:
                    centerbutton.Source = "light.png";
                    break;
            }

            await centerbutton.TranslateTo(displacement, centerbutton.Y + 15, 0);
            await Task.WhenAll(
                centerbutton.FadeTo(1, transitionTime, Easing.Linear),
                centerbutton.TranslateTo(0, 0, transitionTime, Easing.Linear));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            switch (Theme)
            {
                case Theme.Light:
                    Theme = Theme.Dark;
                    break;
                default:
                    Theme = Theme.Light;
                    break;
            }
        }
    }

    public enum Theme
    {
        Light,
        Dark
    }
}
