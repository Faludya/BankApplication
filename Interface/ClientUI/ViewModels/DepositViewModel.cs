using ClientLib.Controllers;
using Database;
using System.Collections.ObjectModel;

namespace Interface.ClientUI.ViewModels
{
    public class DepositViewModel : BaseViewModel
    {
        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set => _accounts = value;
        }

        public DepositViewModel(ObservableCollection<Account> accounts)
        {
            Accounts = accounts;
        }

        public override bool CheckData()
        {
            if (SelectedAccount == null)
                return false;

            if (SelectedCurrency == null)
                return false;

            if (!decimal.TryParse(DepositAmount.ToString(), out decimal resultTotal))
                return false;

            if (DepositAmount <= 0)
                return false;

            return true;
        }

        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
            }
        }

        private string _selectedCurrency;
        public string SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                if (_selectedCurrency == "0")
                    SelectedAccount.Currency = "RON";
                else
                if (_selectedCurrency == "1")
                    SelectedAccount.Currency = "EURO";
            }
        }

        private decimal _depositAmount;
        public decimal DepositAmount
        {
            get => _depositAmount;
            set
            {
                if (decimal.TryParse(value.ToString(), out decimal result))
                    _depositAmount = value;

            }
        }
    }
}
