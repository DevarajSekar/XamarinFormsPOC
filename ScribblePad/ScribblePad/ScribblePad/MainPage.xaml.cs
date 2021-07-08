using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScribblePad
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void b1_Clicked(object sender, EventArgs e)
        {
            parent1.Children.RemoveAt(0);
            Color color = (sender as Button).BackgroundColor;
            drawingPad = new Xamarin.CommunityToolkit.UI.Views.DrawingView()
            {
                LineColor = color,
                LineWidth = 15,
                BackgroundColor = Color.WhiteSmoke,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            parent1.Children.Add(drawingPad);
        }
    }
}
