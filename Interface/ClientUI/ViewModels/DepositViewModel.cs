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
    public class DepositViewModel
    {
        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set => _accounts = value;
        }

        public DepositViewModel(int clientId)
        {
            Accounts = AccountsController.GetClientAccounts(clientId);
        }
    }
}
