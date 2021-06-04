using Newtonsoft.Json;
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

namespace DContacts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var savedValue = Xamarin.Essentials.Preferences.Get("listView", "default_value");
            if (savedValue != "default_value")
            {
                listView.ItemsSource = JsonConvert.DeserializeObject<List<ContactDetail>>(savedValue);
            }
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string result = (e.Item as ContactDetail).Number;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(result[i].ToString()))
                {
                    stringBuilder.Append(result[i]);
                }
            }

            if (!string.IsNullOrEmpty(stringBuilder.ToString()))
            {
                Xamarin.Essentials.PhoneDialer.Open(stringBuilder.ToString());
            }
        }
    }

    public class ContactCollection : BaseViewModel
    {
        private ObservableCollection<ContactDetail> contactCollection;

        public ICommand AddCommand { get; set; }

        public ContactCollection()
        {
            ContactList = new ObservableCollection<ContactDetail>();
            AddCommand = new Command(PickContact);
        }

        public async void PickContact()
        {
            var result = await Xamarin.Essentials.Contacts.PickContactAsync();
            if (result != null)
            {
                ContactList.Add(new ContactDetail()
                {
                    Name = result.DisplayName,
                    Number = result.Phones[0].PhoneNumber,
                    PrefixName = result.DisplayName.Substring(0, 1)
                });

                var savedList = JsonConvert.SerializeObject(ContactList);
                Xamarin.Essentials.Preferences.Set("listView", savedList);
            }
        }

        public ObservableCollection<ContactDetail> ContactList
        {
            get
            {
                return contactCollection;
            }
            set
            {
                contactCollection = value;
                OnPropertyChanged();
            }
        }
    }

    public class ContactDetail : BaseViewModel
    {
        private string number;

        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged();
            }
        }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string prename;

        public string PrefixName
        {
            get
            {
                return prename;
            }
            set
            {
                prename = value;
                OnPropertyChanged();
            }
        }
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
