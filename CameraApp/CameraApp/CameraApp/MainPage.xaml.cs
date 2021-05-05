using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CameraApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (MediaPicker.IsCaptureSupported)
            {
                var selectedImage = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please select a image"
                });

                var stream = await selectedImage.OpenReadAsync();

                PhotoImage.Source = ImageSource.FromStream(() => stream);
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (MediaPicker.IsCaptureSupported)
            {
                var CaptureImage = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = "Please click an Image!!"
                });

                var stream = await CaptureImage.OpenReadAsync();

                PhotoImage.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}
