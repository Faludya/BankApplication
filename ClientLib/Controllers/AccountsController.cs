using Database;
using System.Collections.ObjectModel;

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

        public static bool Withdraw(Account account, decimal withdrawAmount, string withdrawCurrency)
        {
            //Currency Conversion with latest rate
            if (account.Currency != withdrawCurrency)
            {
                decimal conversionResult = ConvertCurrency(withdrawAmount, account.Currency, withdrawCurrency);
                if (conversionResult == -1)
                    return false;

                withdrawAmount = conversionResult;
            }

            //Commission calculation
            decimal withdrawCommission = (decimal)account.AccountOffer.WithdrawCommission / 100m * withdrawAmount + (decimal)account.AccountOffer.WithdrawFixTax;
            withdrawAmount += withdrawCommission;

            if (withdrawAmount > account.Total)
                return false;

            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.UpdateAccountTotal(account.IBAN, withdrawAmount, withdrawCommission,  -1);
            }
        }

        public static bool Deposit(Account account, decimal depositAmount, string withdrawCurrency)
        {
            //Currency Conversion with latest rate
            if (account.Currency != withdrawCurrency)
            {
                decimal conversionResult = ConvertCurrency(depositAmount, account.Currency, withdrawCurrency);
                if (conversionResult == -1)
                    return false;

                depositAmount = conversionResult;
            }

            //Commission calculation
            decimal depositCommission = (decimal)account.AccountOffer.DepositCommission / 100m * depositAmount;
            depositAmount -= depositCommission;

            //Deposit the sum remained after commission
            using (Service.ServiceClient service = new Service.ServiceClient())
            {

                return service.UpdateAccountTotal(account.IBAN, depositAmount, depositCommission, 1);
            }
        }

        public static decimal ConvertCurrency(decimal initialAmount, string accountCurrency, string withdrawCurrency)
        {
            ExchangeCurrency rate;
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                rate = service.GetLastExchangeRate();
            }
            if (accountCurrency == "RON" && withdrawCurrency == "EURO")
            {
                return initialAmount * rate.Ron;
            }
            else
            if (accountCurrency == "EURO" && withdrawCurrency == "RON")
            {
                return initialAmount / rate.Ron;
            }
            else
               if (accountCurrency == "RON" && withdrawCurrency == "RON")
            {
                return initialAmount;
            }
            if (accountCurrency == "EURO" && withdrawCurrency == "EURO")
            {
                return initialAmount;
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
