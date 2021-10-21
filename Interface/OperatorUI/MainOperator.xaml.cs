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
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Interface.OperatorUI
{
    /// <summary>
    /// Interaction logic for MainOperator.xaml
    /// </summary>
    public partial class MainOperator : Window
    {
        public MainOperator()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); InitializeTree();
        }

        private void InitializeTree()
        {
            RadTreeViewItem viewClients = new RadTreeViewItem();
            viewClients.Header = "Clients";
            viewClients.Tag = "Clients";

            RadTreeViewItem viewAccounts = new RadTreeViewItem();
            viewAccounts.Header = "Accounts";
            viewAccounts.Tag = "Accounts";

            RadTreeViewItem accountOffers = new RadTreeViewItem();
            accountOffers.Header = "Account Offers";
            accountOffers.Tag = "Account Offers";

            RadTreeViewItem tranzactions = new RadTreeViewItem();
            tranzactions.Header = "Tranzactions";
            tranzactions.Tag = "Tranzactions";

            RadTreeViewItem security = new RadTreeViewItem();
            security.Header = "Security";
            security.Tag = "Security";

            security.Items.Add(viewClients);
            security.Items.Add(viewAccounts);
            security.Items.Add(accountOffers);
            security.Items.Add(tranzactions);

            tree.Items.Add(security);
            //TODO: finish adding machines, scanprofiles...
        }

        private void Tree_ItemDoubleClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {

        }
    }
}
