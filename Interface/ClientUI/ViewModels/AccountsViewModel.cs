using ClientLib.Controllers;
using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.ClientUI.ViewModels
{
    public class AccountsViewModel
    {
        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set => _accounts = value;
        }
        public AccountsViewModel(int clientId)
        {
            Accounts = AccountsController.GetClientAccounts(clientId);
        }
    }
}
