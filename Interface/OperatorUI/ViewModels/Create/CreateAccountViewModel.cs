using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.OperatorUI.ViewModels.Create
{
    public class CreateAccountViewModel : BaseViewModel
    {
        private Account _account;
        public Account Account
        {
            get => _account;
            set => _account = value;
        }

        public CreateAccountViewModel()
        {
            Account = new Account();
        }

        public override void Trim()
        {
            Account.IBAN.Trim();
            Account.Currency.Trim();
        }

    }
}
