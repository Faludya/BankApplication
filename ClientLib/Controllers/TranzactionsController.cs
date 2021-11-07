using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Controllers
{
    public class TranzactionsController
    {
        public static ObservableCollection<Tranzaction> GetAccountTranzactions(int accountId)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.GetAccountTranzactions(accountId);
            }
        }
    }
}
