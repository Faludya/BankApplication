using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Operator.Controllers
{
    public class GridController
    {
        public static ObservableCollection<Client> GetAllClients()
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.GetClients();
            }
        }

        public static ObservableCollection<Account> GetAllAccounts()
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.GetAccounts();
            }
        }

        public static ObservableCollection<AccountOffer> GetAllAccountOffers()
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.GetAccountOffers();
            }
        }

        public static ObservableCollection<Tranzaction> GetAllTranzactions()
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.GetTranzactions();
            }
        }

        public static List<string> GetAllCurrencies()
        {
            List<string> currencies = new List<string>();
            currencies.Add("RON");
            currencies.Add("EURO");

            return currencies;
        }
    }
}
