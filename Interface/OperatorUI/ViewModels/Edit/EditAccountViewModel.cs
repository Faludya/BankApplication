using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.OperatorUI.ViewModels.Edit
{
    public class EditAccountViewModel : BaseViewModel
    {
        private Account _account;
        public Account Account
        {
            get => _account;
            set => _account = value;
        }

        public EditAccountViewModel(Account account)
        {
            Account = account;
        }
    }
}
