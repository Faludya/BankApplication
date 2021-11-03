using Interface.OperatorUI.ViewModels.Create;
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

namespace Interface.OperatorUI.Views.Create
{
    /// <summary>
    /// Interaction logic for CreateTranzactionView.xaml
    /// </summary>
    public partial class CreateTranzactionView : UserControl
    {
        public CreateTranzactionView()
        {
            InitializeComponent();
        }

        private void Client_combobox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            source_client_combobox.IsDropDownOpen = true;
        }

        private void Source_client_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is CreateTranzactionViewModel)
            {
                source_iban_combobox.ItemsSource = (DataContext as CreateTranzactionViewModel).ClientSourceAccounts;
                source_iban_combobox.SelectedIndex = 0;
            }
        }

        private void Destination_client_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is CreateTranzactionViewModel)
            {
                destination_iban_combobox.ItemsSource = (DataContext as CreateTranzactionViewModel).ClientDestinationAccounts;
                destination_iban_combobox.SelectedIndex = 0;
            }
        }
    }
}
