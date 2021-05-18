using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;

namespace SnackBarAndToast
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var action = new SnackBarActionOptions
            {
                Action = () =>

                      DisplayAlert("Toast Option clicked", "You have checked my Sample", "OK!"),
                Text = "No, then click here!",
                ForegroundColor = Color.White
            };

            var options = new SnackBarOptions()
            {
                BackgroundColor = Color.FromHex("#2196F3"),
                Duration = TimeSpan.FromSeconds(10),
                MessageOptions = new MessageOptions()
                {
                    Message = "Did you checked the Bread TOAST!!",
                    Foreground = Color.White,
                    Padding = 10
                },
                Actions = new[] { action }
            };

            await this.DisplaySnackBarAsync(options);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var action = new SnackBarActionOptions
            {
                Action = () =>

                      DisplayAlert("SnackBar Option clicked", "OOPS!! I came from the Top", "OK!"),
                Text = "No, then click here!",
                ForegroundColor = Color.Black
            };

            var options = new SnackBarOptions()
            {
                BackgroundColor = Color.LightCoral,
                Duration = TimeSpan.FromSeconds(10),
                MessageOptions = new MessageOptions()
                {
                    Message = "Did you checked the Snacks Bar!!",
                    Foreground = Color.Black,
                    Padding = 10
                },
                Actions = new[] { action }
            };

            await (sender as VisualElement).DisplaySnackBarAsync(options);
        }
    }
}