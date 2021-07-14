using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iBarcodeReader
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
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