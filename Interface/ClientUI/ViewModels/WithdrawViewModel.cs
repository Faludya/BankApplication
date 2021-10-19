using ClientLib.Controllers;
using Database;
using System.Collections.ObjectModel;

namespace Interface.ClientUI.ViewModels
{
    public class WithdrawViewModel
    {
        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set => _accounts = value;
        }

        public WithdrawViewModel(int clientId)
        {
            Accounts = AccountsController.GetClientAccounts(clientId);
        }
    }
}
