using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageBarcode
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var image = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            var stream = await image.OpenReadAsync();
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, bytes.Length);
            stream.Seek(0, System.IO.SeekOrigin.Begin);

            var resut = await GoogleVisionBarCodeScanner.Methods.ScanFromImage(bytes);

            var resultString = string.Empty;

            foreach(var barcode in resut)
            {
                resultString += $"Type:{barcode.BarcodeType}, value:{barcode.DisplayValue}{Environment.NewLine}";

                Device.BeginInvokeOnMainThread(() =>
                {
                    label.Text = resultString;
                });
            }
        }
    }
}
