using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.ClientUI.ViewModels
{
    public class ChangePinViewModel
    {
        private int _clientId;
        public int ClientId
        {
            get => _clientId;
            set => _clientId = value;
        }
        public ChangePinViewModel(int id)
        {
            ClientId = id;
        }
    }
}
