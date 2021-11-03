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
    public class ClientsGridViewModel : BaseViewModel
    {
        public ClientsGridViewModel()
        {
            Clients = GridController.GetAllClients();
        }

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients 
        {
            get => _clients;
            set => _clients = value;
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set => _selectedClient = value;
        }

    }
}
