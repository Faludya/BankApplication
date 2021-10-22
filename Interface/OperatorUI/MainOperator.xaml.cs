using ClientLib.Operator.Controllers;
using Database;
using Interface.OperatorUI.ViewModels;
using System.Windows;
using Telerik.Windows.Controls;

namespace Interface.OperatorUI
{
    /// <summary>
    /// Interaction logic for MainOperator.xaml
    /// </summary>
    public partial class MainOperator : Window
    {
        private RadGridView gridView;
        public MainOperator()
        {
            InitializeComponent();

            DataContext = new MainViewModel(); 
            InitializeTree();
            gridView = new RadGridView
            {
                ShowGroupPanel = false,
                FontSize = 24,
                
            };
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
            string selectedItem = ((RadTreeViewItem)tree.SelectedItem).Tag.ToString();

            switch (selectedItem)
            {
                case "Clients":
                    gridView.ItemsSource = GridController.GetAllClients();
                    gridView.Columns["PIN"].IsVisible = false;
                    gridView.Columns["Accounts"].IsVisible = false;
                    break;

                case "Accounts":
                    gridView.ItemsSource = GridController.GetAllAccounts();
                    gridView.Columns["AccountOffer"].IsVisible = false;
                    gridView.Columns["Client"].IsVisible = false;
                    gridView.Columns["Tranzactions"].IsVisible = false;
                    gridView.Columns["Tranzactions1"].IsVisible = false;
                    break;

                case "Account Offers":
                    gridView.ItemsSource = GridController.GetAllAccountOffers();
                    gridView.Columns["Accounts"].IsVisible = false;
                    break;

                case "Tranzactions":
                    gridView.ItemsSource = GridController.GetAllTranzactions();
                    gridView.Columns["Account"].IsVisible = false;
                    gridView.Columns["Account1"].IsVisible = false;
                    break;

                default:
                    break;
            }

            contentPresenter.Content = gridView;
        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (gridView.SelectedItem is Client)
                contentPresenter.Content = new EditClientViewModel(gridView.SelectedItem as Client);
            else
            if (gridView.SelectedItem is AccountOffer)
                contentPresenter.Content = new EditAccountOfferViewModel(gridView.SelectedItem as AccountOffer);
        }

        private void Save_button_Click(object sender, RoutedEventArgs e)
        {

            if(contentPresenter.Content is EditClientViewModel)
            {
                var viewModel = contentPresenter.DataContext as EditClientViewModel;
                if (EditSecurityController.UpdateClient(viewModel.Client))
                {
                    MessageBox.Show("Client Updated!");
                    gridView.ItemsSource = GridController.GetAllClients();
                    contentPresenter.Content = gridView;
                }
               

            }
        }
    }
}
