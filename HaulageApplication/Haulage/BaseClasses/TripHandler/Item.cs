using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    public class Item
    {
        public Guid itemID;
        public string description;
        public bool itemCategory;
        public bool signedOff;
        public Item() { }

        public void inspectItem(){

        }

    }
}
