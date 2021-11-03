using ClientLib.Operator.Controllers;
using Database;
using System.Collections.ObjectModel;

namespace Interface.OperatorUI.ViewModels.Grids
{
    public class AccountsGridViewModel : BaseViewModel
    {
        public AccountsGridViewModel()
        {
            Accounts = GridController.GetAllAccounts();
        }

        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set => _accounts = value;
        }

        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get => _selectedAccount;
            set => _selectedAccount = value;
        }
    }
}
