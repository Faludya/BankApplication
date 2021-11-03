using ClientLib.Operator.Controllers;
using Database;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Interface.OperatorUI.ViewModels.Create
{
    public class CreateAccountViewModel : BaseViewModel
    {
        public CreateAccountViewModel()
        {
            Account = new Account();
            AccountOffers = GridController.GetAllAccountOffers();
            Clients = GridController.GetAllClients();
            Currencies = GridController.GetAllCurrencies();
        }

        public override void Trim()
        {
            Account.IBAN.Trim();
            Account.Currency.Trim();
        }

        public override bool CheckData()
        {
            if (Account == null || SelectedAccountOffer == null || 
                SelectedClient == null || SelectedCurrency == null)
                return false;

            //Selected Account Offer
            if (SelectedAccountOffer.Name == "")
                return false;

            //Valid Total
            if(!decimal.TryParse(Account.Total.ToString(), out decimal result))
                return false;

            //If IBAN generated
            if (Account.IBAN == "" || Account.IBAN == null)
                return false;

            //Selected Client
            if (SelectedClient.FullName == "")
                return false;
            
            return true;
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

        private List<string> _currencies;
        public List<string> Currencies
        {
            get => _currencies;
            set
            {
                _currencies = value;
            }
        }

        private string _selectedCurrency;
        public string SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                Account.Currency = _selectedCurrency;
            }
        }
    }
}
