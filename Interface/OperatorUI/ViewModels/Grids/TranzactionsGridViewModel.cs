using ClientLib.Operator.Controllers;
using Database;
using System.Collections.ObjectModel;

namespace Interface.OperatorUI.ViewModels.Grids
{
    public class TranzactionsGridViewModel : BaseViewModel
    {
        public TranzactionsGridViewModel()
        {
            Tranzactions = GridController.GetAllTranzactions();
        }

        private ObservableCollection<Tranzaction> _tranzactions;
        public ObservableCollection<Tranzaction> Tranzactions
        {
            get => _tranzactions;
            set => _tranzactions = value;
        }
    }
}
