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
    public class TranzactionsViewModel : BaseViewModel
    {
        public TranzactionsViewModel(ObservableCollection<Account> accounts)
        {
            AccountsList = accounts;
            TranzactionsList = new ObservableCollection<Tranzaction>();
            SelectedAccount = new Account();
        }

        private void UpdateTranzactions()
        {
            TranzactionsList = TranzactionsController.GetAccountTranzactions(_selectedAccount.Id);
        }

        private ObservableCollection<Account> _accountsList;
        public ObservableCollection<Account> AccountsList
        {
            get => _accountsList;
            set => _accountsList = value;
        }

        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                UpdateTranzactions();
            }
        }

        private ObservableCollection<Tranzaction> _tranzactionsList;
        public ObservableCollection<Tranzaction> TranzactionsList
        {
            get => _tranzactionsList;
            set => _tranzactionsList = value;
        }
    }
}
