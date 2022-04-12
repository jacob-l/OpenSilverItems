using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using OpenSilverAsyncLoading.Annotations;

namespace OpenSilverAsyncLoading
{
    public class Model : INotifyPropertyChanged
    {
        private List<string> _items = new List<string> { "0" };

        public Model()
        {
        }

        public List<string> Items
        {
            get
            {
                Console.WriteLine("Get items");
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddItem()
        {
            _items.Add(_items.Count.ToString());

            OnPropertyChanged("Items");
        }
    }

    public partial class MainPage : Page
    {
        private Model model = new Model();

        public MainPage()
        {
            this.InitializeComponent();

            // Enter construction logic here...
            DataContext = model;
        }

        public void OnClick(object sender, EventArgs args)
        {
            model.AddItem();
        }
    }
}
