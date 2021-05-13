using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DragAndDrop
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
        {
            var label = (sender as Element)?.Parent as Label;
            e.Data.Properties.Add("Text", label.Text);
        }

        private async void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
        {
            //var data = await e.Data.GetTextAsync();
            if (e.Data.Properties.Keys.ToArray()[0].ToString() == "Text")
            {
                var data = e.Data.Properties["Text"].ToString();
                var frame = (sender as Element)?.Parent as Frame;
                frame.Content = new Label()
                {
                    Text = data
                };
            }
            else if (e.Data.Properties.Keys.ToArray()[0].ToString() == "Image")
            {
                var data = await e.Data.GetImageAsync();
                var frame = (sender as Element)?.Parent as Frame;
                frame.Content = new Image()
                {
                    Source = data
                };
            }
        }

        private void DragGestureRecognizer_DragStarting_1(object sender, DragStartingEventArgs e)
        {
            var image = (sender as Element)?.Parent as Image;
            e.Data.Properties.Add("Image", image.Source);
        }
    }
}
