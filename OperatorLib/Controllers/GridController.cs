using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorLib.Controllers
{
    public class GridController
    {
        public static ObservableCollection<OperatorService.Client> GetAllClients()
        {
            using (OperatorService.ServiceClient service = new OperatorService.ServiceClient())
            {
                return service.GetClients();
            }
        }

        public static ObservableCollection<OperatorService.Account> GetAllAccounts()
        {
            using (OperatorService.ServiceClient service = new OperatorService.ServiceClient())
            {
                return service.GetAccounts();
            }
        }

        public static ObservableCollection<OperatorService.AccountOffer> GetAllAccountOffers()
        {
            using (OperatorService.ServiceClient service = new OperatorService.ServiceClient())
            {
                return service.GetAccountOffers();
            }
        }

        public static ObservableCollection<OperatorService.Tranzaction> GetAllTranzactions()
        {
            using (OperatorService.ServiceClient service = new OperatorService.ServiceClient())
            {
                return service.GetTranzactions();
            }
        }
    }
}
