using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ValueConverter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class ModelClass : INotifyPropertyChanged
    {
        public int Color { get; set; } = 1;

        public ObservableCollection<GenderClass> MyList { get; set; } = new ObservableCollection<GenderClass>()
        {
             new GenderClass(){ Name="Male", MyGender= Gender.Male },
             new GenderClass(){ Name="Female", MyGender= Gender.Female },
             new GenderClass(){ Name="Male", MyGender= Gender.Male },
             new GenderClass(){ Name="Female", MyGender= Gender.Female },
             new GenderClass(){ Name="Male", MyGender= Gender.Male },
        };

        public Gender Gender { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class GenderClass
    {
        public Gender MyGender { get; set; }

        public string Name { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Color.LightBlue;

            var result = value;

            switch (result)
            {
                case (Gender.Male):
                    return Color.LightBlue;
                default:
                    return Color.LightPink;
            }
                
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
