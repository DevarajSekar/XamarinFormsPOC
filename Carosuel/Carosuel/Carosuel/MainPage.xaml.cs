using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace Carosuel
{
    public partial class MainPage : ContentPage
    {
        public FavClass FavClassColl;
        public MainPage()
        {
            InitializeComponent();
            FavClassColl = new FavClass();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            carouselView.HeightRequest = height;
        }

        private void carouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            carouselView.BackgroundColor = (e.CurrentItem as Detail).BGColor;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new PopupPage(FavClassColl));
        }

        private void SwipeItem_Clicked(object sender, EventArgs e)
        {
            if (!FavClassColl.FavDetails.Contains(carouselView.CurrentItem))
            {
                FavClassColl.FavDetails.Add(carouselView.CurrentItem as Detail);
            }
        }

        private void SwipeItem_Clicked_1(object sender, EventArgs e)
        {
            if (FavClassColl.FavDetails.Contains(carouselView.CurrentItem))
            {
                FavClassColl.FavDetails.Remove(carouselView.CurrentItem as Detail);
            }
        }
    }

    public class FavClass : INotifyPropertyChanged
    {
        private ObservableCollection<Detail> favDetails;

        public FavClass()
        {
            FavDetails = new ObservableCollection<Detail>();
        }

        public ObservableCollection<Detail> FavDetails
        {
            get
            {
                return favDetails;
            }
            set
            {
                favDetails = value;
                OnPropertyChanged("FavDetails");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class ModelClass
    {
        public ICommand ColorCommand;

        public ObservableCollection<Detail> Details { get; set; }

        public ModelClass()
        {
            Details = new ObservableCollection<Detail>()
            {
                new Detail() { Name = "Nike", ImageName = "nike.jpg", BGColor = Color.FromHex("#f40000")},
                new Detail() { Name = "Adidas", ImageName = "adidas.jpg",BGColor = Color.FromHex("#086591")},
                new Detail() { Name = "Converse", ImageName = "convo.jpg", BGColor = Color.FromHex("#701f22")},
                new Detail() { Name = "Reedbok", ImageName = "reebok.jpg", BGColor = Color.FromHex("#f7b518")},
                new Detail() { Name = "Puma", ImageName = "puma.jpg", BGColor = Color.FromHex("#1e1e1e")},
            };
        }
    }

    public class Detail : INotifyPropertyChanged
    {
        private string name;
        private string img;
        private Color color;

        public Color BGColor
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                OnPropertyChanged("BGColor");
            }
        }

        public string ImageName
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
                OnPropertyChanged("ImageName");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
