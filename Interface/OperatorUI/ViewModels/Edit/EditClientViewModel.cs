using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.OperatorUI.ViewModels
{
    public class EditClientViewModel
    {
        private Client _client;
        public Client Client
        {
            get => _client;
            set => _client = value;
        }

        public EditClientViewModel(Client client)
        {
            Client = client;
        }
    }
}
