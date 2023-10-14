using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DB_CourseProject.ViewModels
{
    class ListOfModels : INotifyPropertyChanged
    {
        private int id;
        private string model;
        private string producer;
        private string typeOfAppliance;

        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("model");
            }
        }
        public string Producer
        {
            get { return producer; }
            set
            {
                producer = value;
                OnPropertyChanged("producer");
            }
        }
        public string TypeOfAppliance
        {
            get { return typeOfAppliance; }
            set
            {
                typeOfAppliance = value;
                OnPropertyChanged("typeOfAppliance");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
