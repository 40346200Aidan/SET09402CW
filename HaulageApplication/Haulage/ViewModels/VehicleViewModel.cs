using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses.Accounting;
using Haulage.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Haulage.viewModel
{
    public class VehicleViewModel
    {
        public ObservableCollection<Vehicle> Vehicles { get; set; }
        public VehicleViewModel() 
        {
            Vehicles = new ObservableCollection<Vehicle>();
            var vehicleObjects = VehicleModel.vehicles;
            foreach (var vehicleObject in vehicleObjects) 
            {
                Vehicles.Add(vehicleObject);
            }
        }
    }
}
