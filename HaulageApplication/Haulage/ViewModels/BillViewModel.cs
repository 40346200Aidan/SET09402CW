using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses.Accounting;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Haulage.DatabaseExecutionServices;
using Haulage.BaseClasses.BillingHandler;

namespace Haulage.BillviewModel
{
    public class BillViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Billing>? Bills { get; set; }
        public BillViewModel() 
        {
            Bills = new ObservableCollection<Billing>();
            var BillingObjects = BillModel.Bills;
            foreach (var BillObject in BillingObjects)
            {
                Bills.Add(BillObject);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}