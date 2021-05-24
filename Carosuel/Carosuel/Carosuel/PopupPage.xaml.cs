using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carosuel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPage : Popup
    {
        public PopupPage(FavClass favClass)
        {
            InitializeComponent();

            ListView listView = new ListView();
            listView.HeightRequest = 100;
            listView.BackgroundColor = Color.LightGray;
            listView.BindingContext = favClass;
            listView.ItemsSource = favClass.FavDetails;
            var template = new DataTemplate(() =>
            {
                Grid grid = new Grid();

                Label label1 = new Label();
                label1.TextColor = Color.Black;
                label1.FontAttributes = FontAttributes.Bold;
                label1.FontSize = 22;
                label1.HorizontalTextAlignment = TextAlignment.Center;
                label1.Text = "Added Item: ";
                grid.Children.Add(label1, 0, 0);

                Label label = new Label();
                label.TextColor = Color.Black;
                label.FontAttributes = FontAttributes.Bold;
                label.FontSize = 22;
                label.HorizontalTextAlignment = TextAlignment.Center;
                label.SetBinding(Label.TextProperty, "Name");
                grid.Children.Add(label, 1, 0);
                return new ViewCell { View = grid };
            });

            listView.ItemTemplate = template;

            if (favClass.FavDetails.Count > 0)
            {
                this.Content = listView;
            }
            else
            {
                Label label = new Label();
                label.TextColor = Color.Black;
                label.FontAttributes = FontAttributes.Bold;
                label.FontSize = 22;
                label.HorizontalTextAlignment = TextAlignment.Center;
                label.Text = "No Favorites Added!";
                this.Content = label;
            }
        }
    }
}