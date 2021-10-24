using ClientLib.Operator.Controllers;
using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Interface.OperatorUI.ViewModels.Create
{
    public class CreateAccountViewModel : BaseViewModel
    {
        public CreateAccountViewModel()
        {
            Account = new Account();
            AccountOffers = GridController.GetAllAccountOffers();
            Clients = GridController.GetAllClients();
        }

        public override void Trim()
        {
            Account.IBAN.Trim();
            Account.Currency.Trim();
        }


        private Account _account;
        public Account Account
        {
            get => _account;
            set => _account = value;
        }

        //Lists 
        private ObservableCollection<AccountOffer> _accountOffers;
        public ObservableCollection<AccountOffer> AccountOffers
        {
            get => _accountOffers;
            set => _accountOffers = value;
        }

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => _clients = value;
        }


        //Selected items
        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                Account.ID_Client = _selectedClient.Id;
            }
        }

        private AccountOffer _selectedAccountOffer;
        public AccountOffer SelectedAccountOffer
        {
            get => _selectedAccountOffer;
            set
            {
                _selectedAccountOffer = value;
                Account.ID_Offer = _selectedAccountOffer.Id;
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
                    Account.Currency = "RON";
                else
                if (_selectedCurrency == "1")
                    Account.Currency = "EURO";
            }
        }


    }
}
