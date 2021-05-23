using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Carosuel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void carouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            carouselView.BackgroundColor = (e.CurrentItem as Detail).BGColor;
        }
    }

    public class ModelClass
    {
        public ObservableCollection<Detail> Details { get; set; }

        public ModelClass()
        {
            Details = new ObservableCollection<Detail>()
            {
                new Detail(){Name = "Nike", ImageName="nike.jpg", BGColor=Color.FromHex("#f40000")},
                new Detail(){Name = "Adidas", ImageName="adidas.jpg",BGColor=Color.FromHex("#086591")},
                new Detail(){Name = "Converse", ImageName="convo.jpg", BGColor= Color.FromHex("#701f22")},
                new Detail(){Name = "Reedbok", ImageName="reebok.jpg", BGColor=Color.FromHex("#f7b518")},
                new Detail(){Name = "Puma", ImageName="puma.jpg", BGColor=Color.FromHex("#1e1e1e")},
            };
        }
    }

    public class Detail : INotifyPropertyChanged
    {
        public Detail()
        {
            ColorCommand = new Command<Detail>((item) =>
            {
                
            });
        }

        void ChangeColor()
        {
            
        }
            

        private string name;
        private string img;
        private Color color;
        public ICommand ColorCommand;

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
