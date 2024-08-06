using Haulage.BaseClasses.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.BillingHandler
{
    public class Billing
    {
       public int BillId { get; set; }
       public string Fullname { get; set; }
       public string Email { get; set; }
       public string Item {  get; set; }
       public string ItemDesc { get; set; }
       public double Cost { get; set; }
       public string Paid { get; set; }
        public Billing() { }

        public Billing(int customerBillId, string customerFullname, string customerEmail, string customerItem, string customerItemDesc, double customerItemCost)
        {
            this.BillId = customerBillId;
            this.Fullname = customerFullname;
            this.Email = customerEmail;
            this.Item = customerItem;
            this.ItemDesc = customerItemDesc;
            this.Cost = customerItemCost;
          
        }

    }
}
