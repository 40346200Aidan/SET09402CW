using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.Accounting;
using Haulage.BaseClasses.BillingHandler;

namespace Haulage.DatabaseExecutionServices
{
    public static class BillModel
    {
        public static List<Billing> Bills = BillExecutionService.GetBills();

    }
}
