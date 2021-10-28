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

        public static bool UpdateClientPin(int clientId,string oldPin, string newPin, string confirmPin)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return CanUpdatePin(oldPin, newPin, confirmPin) ? service.ChangeClientPin(clientId, oldPin, newPin) : false;
            }
        }

        public static bool Withdraw(string iban, decimal withdrawAmount, string accountCurrency, string withdrawCurrency)
        {
            if (accountCurrency != withdrawCurrency)
            {
                decimal conversionResult = ConvertCurrency(withdrawAmount, accountCurrency, withdrawCurrency);
                if (conversionResult == -1)
                    return false;

                withdrawAmount = conversionResult;
            }

            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.UpdateAccountTotal(iban, withdrawAmount, -1);
            }
        }

        public static bool Deposit(string iban, decimal withdrawAmount, string accountCurrency, string withdrawCurrency)
        {
            if (accountCurrency != withdrawCurrency)
            {
                decimal conversionResult = ConvertCurrency(withdrawAmount, accountCurrency, withdrawCurrency);
                if (conversionResult == -1)
                    return false;

                withdrawAmount = conversionResult;
            }



            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.UpdateAccountTotal(iban, withdrawAmount, 1);
            }
        }

        private static decimal ConvertCurrency(decimal initialAmount, string accountCurrency, string withdrawCurrency)
        {
            if(accountCurrency == "RON" && withdrawCurrency == "EURO")
            {
                return initialAmount * 4.5m;
            }
            else
            if (accountCurrency == "EURO" && withdrawCurrency == "RON")
            {
                return initialAmount / 4.5m;
            }
  
            return -1;
        }

        private static bool CanUpdatePin(string oldPin, string newPin, string confirmPin)
        {
            if (oldPin == "" || newPin == "" || confirmPin == "")
                return false;

            if (newPin != confirmPin)
                return false;

            return true;
        }
    }
}
