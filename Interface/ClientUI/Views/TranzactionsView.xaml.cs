using Interface.ClientUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface.ClientUI.Views
{
    /// <summary>
    /// Interaction logic for TranzactionsView.xaml
    /// </summary>
    public partial class TranzactionsView : UserControl
    {
        public TranzactionsView()
        {
            InitializeComponent();
        }

        private void Iban_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataContext as TranzactionsViewModel != null)
            {
                gridView.ItemsSource = (DataContext as TranzactionsViewModel).TranzactionsList;
            }
        }
    }
}
