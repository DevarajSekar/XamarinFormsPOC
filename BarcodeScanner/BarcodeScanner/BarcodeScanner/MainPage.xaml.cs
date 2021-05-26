using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarcodeScanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                scanner.IsScanning = false;
                resultLabel.Text = "Info : " + result.Text + "\nBarcode Type : " +
                    result.BarcodeFormat.ToString();
            });

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            scanner.IsScanning = true;
        }
    }
}
