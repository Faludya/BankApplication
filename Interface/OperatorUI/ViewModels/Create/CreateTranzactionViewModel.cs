using ClientLib.Controllers;
using ClientLib.Operator.Controllers;
using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.OperatorUI.ViewModels.Create
{
    public class CreateTranzactionViewModel : BaseViewModel
    {
        public CreateTranzactionViewModel()
        {
            ClientsList = GridController.GetAllClients();
            ClientSourceAccounts = new ObservableCollection<Account>();
            ClientDestinationAccounts = new ObservableCollection<Account>();
            Tranzaction = new Tranzaction();
        }

        public override bool CheckData()
        {
            //Check Source Client
            if (SelectedSourceClient == null)
                return false;

            //Check Source IBAN
            if (SelectedSourceAccount == null)
                return false;

            //Check Source Amount
            if (TransferAmount <= 0)
                return false;

            //Check Destination Client
            if (SelectedDestinationClient == null)
                return false;

            //Check Destination IBAN
            if (SelectedDestinationAccount == null)
                return false; 

            return true;
        }

        private Tranzaction _tranzaction;
        public Tranzaction Tranzaction
        {
            get => _tranzaction;
            set => _tranzaction = value;
        }

        //List
        private ObservableCollection<Client> _clientsList;
        public ObservableCollection<Client> ClientsList
        {
            get => _clientsList;
            set => _clientsList = value;
        }


        //Source Account
        private Account _selectedSourceAccount;
        public Account SelectedSourceAccount
        {
            get => _selectedSourceAccount;
            set
            {
                _selectedSourceAccount = value;
                if (_selectedSourceAccount != null)
                {
                    Tranzaction.Id_SourceAccount = _selectedSourceAccount.Id;
                    Tranzaction.Source_Currency = _selectedSourceAccount.Currency;
                    Tranzaction.Account = _selectedSourceAccount;
                }
            }
        }

        private Client _selectedSourceClient;
        public Client SelectedSourceClient
        {
            get => _selectedSourceClient;
            set
            {
                _selectedSourceClient = value;
                ClientSourceAccounts = AccountsController.GetClientAccounts(_selectedSourceClient.Id);
            }
        }

        private ObservableCollection<Account> _clientSourceAccounts;
        public ObservableCollection<Account> ClientSourceAccounts
        {
            get => _clientSourceAccounts;
            set => _clientSourceAccounts = value;
        }

        private decimal _transferAmount;
        public decimal TransferAmount
        {
            get => _transferAmount;
            set
            {
                _transferAmount = value;
                Tranzaction.Ammount = _transferAmount;
            }
        }

        //Destination Account
        private Account _selectedDestinationAccount;
        public Account SelectedDestinationAccount
        {
            get => _selectedDestinationAccount;
            set
            {
                _selectedDestinationAccount = value;
                if(_selectedDestinationAccount != null)
                {
                    Tranzaction.ID_DestinationAccount = _selectedDestinationAccount.Id;
                    Tranzaction.Destination_Currency = _selectedDestinationAccount.Currency;
                    Tranzaction.Account1 = _selectedDestinationAccount;
                }
            }
        }

        private Client _selectedDestinationClient;
        public Client SelectedDestinationClient
        {
            get => _selectedDestinationClient;
            set
            {
                _selectedDestinationClient = value;
                ClientDestinationAccounts = AccountsController.GetClientAccounts(_selectedDestinationClient.Id);
            }
        }

        private ObservableCollection<Account> _clientDestinationAccounts;
        public ObservableCollection<Account> ClientDestinationAccounts
        {
            get => _clientDestinationAccounts;
            set => _clientDestinationAccounts = value;
        }
    }
}
