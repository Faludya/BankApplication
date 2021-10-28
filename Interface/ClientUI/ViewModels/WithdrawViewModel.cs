using ClientLib.Controllers;
using Database;
using System.Collections.ObjectModel;

namespace Interface.ClientUI.ViewModels
{
    public class WithdrawViewModel : BaseViewModel
    {
        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set => _accounts = value;
        }

        public WithdrawViewModel(ObservableCollection<Account> accounts)
        {
            Accounts = accounts;
        }

        public override bool CheckData()
        {
            if (SelectedAccount == null)
                return false;

            if (SelectedCurrency == null)
                return false;

            if (!decimal.TryParse(WithdrawAmount.ToString(), out decimal resultTotal))
                return false;

            if (WithdrawAmount <= 0)
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

        private decimal _withdrawAmount;
        public decimal WithdrawAmount
        {
            get => _withdrawAmount;
            set
            {
                if (decimal.TryParse(value.ToString(), out decimal result))
                    _withdrawAmount = value;

            }
        }
    }
}
