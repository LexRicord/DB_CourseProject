using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CourseProject.ViewModels
{
    public class Services : INotifyPropertyChanged
    {
        private string _price;

        public string Name { get; set; }
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public int EstimCompTime { get; set; }
        public string typename { get; set; }
        public int ServiceId { get; set; }

        public Services(string name, string price, int estimCompTime, string type, int serviceId)
        {
            Name = name;
            Price = price;
            EstimCompTime = estimCompTime;
            typename = type;
            ServiceId = serviceId;
        }

        public Services(string name, string price, string type)
        {
            Name = name;
            Price = price;
            typename = type;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}