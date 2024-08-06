using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses.Accounting;
using Haulage.DatabaseExecutionServices;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;


namespace Haulage.viewModel
{
    public class DriverViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Driver>? Drivers { get; set; }
        public DriverViewModel()
        {
            Drivers = new ObservableCollection<Driver>();
            var DriverObjects = DriverModel.Drivers;
            foreach (var DriverObject in DriverObjects)
            {
                Drivers.Add(DriverObject);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}