using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Behaviors
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class ModelClass: BaseViewModel
    {
        private int count;
        private string item;

        public ICommand ControlCommand { get; set; }

        public ModelClass()
        {
            ControlCommand = new Command<string>((s) => UpdateCount(s));
        }

        void UpdateCount(string s)
        {
            Count++;
            Item = s;
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }

        public string Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Base view model for entire project. 
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
