using NativeMedia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MultiSelect
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var files = await MediaGallery.PickAsync(2, MediaFileType.Image);

            if (files != null)
            {
                int i = 0;
                foreach (var file in files.Files)
                {
                    var imgStream = await file.OpenReadAsync();
                    Image image = new Image();
                    image.Source = ImageSource.FromStream(() => imgStream);
                    parentGrid.Children.Add(image, 0, i);
                    i++;
                }
            }
        }
    }
}
