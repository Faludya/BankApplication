using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Controllers
{
    public class AccountsController
    {
        public static ObservableCollection<Account> GetClientAccounts(int clientId)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.GetClientAccounts(clientId);
            }
        }
    }
}
