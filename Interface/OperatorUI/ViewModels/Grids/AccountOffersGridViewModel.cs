using ClientLib.Operator.Controllers;
using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.OperatorUI.ViewModels.Grids
{
    public class AccountOffersGridViewModel : BaseViewModel
    {
        public AccountOffersGridViewModel()
        {
            AccountOffers = GridController.GetAllAccountOffers();
        }

        private ObservableCollection<AccountOffer> _accountOffers;
        public ObservableCollection<AccountOffer> AccountOffers
        {
            get => _accountOffers;
            set => _accountOffers = value;
        }

        private AccountOffer _selectedAccountOffer;
        public AccountOffer SelectedAccountOffer
        {
            get => _selectedAccountOffer;
            set => _selectedAccountOffer = value;
        }
    }
}
