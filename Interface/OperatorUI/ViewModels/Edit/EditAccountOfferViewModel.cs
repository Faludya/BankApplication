using ClientLib.Operator.Controllers;
using Database;
using System;
using System.Linq;

namespace Interface.OperatorUI.ViewModels
{
    public class EditAccountOfferViewModel : BaseViewModel
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

        public override bool CheckData()
        {
            return EditSecurityController.CanUpdateAccountOffer(this.AccountOffer);
        }

    }
}
