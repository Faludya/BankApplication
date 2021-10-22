using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.OperatorUI.ViewModels
{
    public class EditAccountOfferViewModel
    {
        private AccountOffer _accountOffer;
        public AccountOffer AccountOffer
        {
            get => _accountOffer;
            set => _accountOffer = value;
        }

        public EditAccountOfferViewModel(AccountOffer accountOffer)
        {
            AccountOffer = accountOffer;
        }
    }
}
