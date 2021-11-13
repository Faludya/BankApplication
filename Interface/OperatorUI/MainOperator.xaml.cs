using ClientLib.Operator.Controllers;
using Database;
using Interface.OperatorUI.ViewModels;
using System.Windows;
using Telerik.Windows.Controls;
using System.Windows.Media;
using Interface.OperatorUI.ViewModels.Edit;
using System.Windows.Controls.Ribbon;
using Interface.OperatorUI.ViewModels.Create;
using Interface.OperatorUI.ViewModels.Grids;
//using System.Windows.Media;

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

            DataContext = new MainViewModel(); 
            InitializeTree();

            StyleManager.ApplicationTheme = new Office_BlueTheme();
            System.Windows.Media.Brush myBrush = new SolidColorBrush(Colors.Transparent);
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
            security.Header = "Customer Service";
            security.Tag = "Customer Service";

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
                    contentPresenter.Content = new ClientsGridViewModel();
                    break;

                case "Accounts":
                    contentPresenter.Content = new AccountsGridViewModel();
                    break;

                case "Account Offers":
                    contentPresenter.Content = new AccountOffersGridViewModel();
                    break;

                case "Tranzactions":
                    contentPresenter.Content = new TranzactionsGridViewModel();
                    break;

                default:
                    break;
            }
        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (contentPresenter.Content is ClientsGridViewModel)
                contentPresenter.Content = new EditClientViewModel((contentPresenter.Content as ClientsGridViewModel).SelectedClient);
            else
            if (contentPresenter.Content is AccountOffersGridViewModel)
                contentPresenter.Content = new EditAccountOfferViewModel((contentPresenter.Content as AccountOffersGridViewModel).SelectedAccountOffer);
            else
            if (contentPresenter.Content is AccountsGridViewModel)
                contentPresenter.Content = new EditAccountViewModel((contentPresenter.Content as AccountsGridViewModel).SelectedAccount);
        }

        private void Save_button_Click(object sender, RoutedEventArgs e)
        {
            if (contentPresenter.Content as BaseViewModel == null)
                return;

            BaseViewModel view = contentPresenter.Content as BaseViewModel;
            if (!view.CheckData())
            {
                MessageBox.Show("Invalid Data!");
                return;
            }

            if (contentPresenter.Content is EditClientViewModel)
            {
                var viewModel = contentPresenter.DataContext as EditClientViewModel;
 
                if (EditSecurityController.UpdateClient(viewModel.Client))
                {
                    MessageBox.Show("Client Updated!");
                    contentPresenter.Content = new ClientsGridViewModel();
                    contentPresenter.Tag = "ClientsGridViewModel";
                }
            }
            else
            if(contentPresenter.Content is EditAccountOfferViewModel)
            {
                var viewModel = contentPresenter.Content as EditAccountOfferViewModel;
                if (EditSecurityController.UpdateAccountOffer(viewModel.AccountOffer))
                {
                    MessageBox.Show("Account Offer Updated!");
                    contentPresenter.Content = new AccountOffersGridViewModel();
                    contentPresenter.Tag = "AccountsGridViewModel";
                }
            }
            else
            if (contentPresenter.Content is CreateAccountViewModel)
            {
                var viewModel = contentPresenter.Content as CreateAccountViewModel;
                if (EditSecurityController.UpdateAccount(viewModel.Account))
                {
                    MessageBox.Show("Account Created!");
                    contentPresenter.Content = new AccountsGridViewModel();
                }
                else
                    MessageBox.Show("Failed to create the account!");
            }
            else
                if(contentPresenter.Content is CreateTranzactionViewModel)
            {
                var viewModel = contentPresenter.Content as CreateTranzactionViewModel;
                if(EditSecurityController.UpdateTranzaction(viewModel.Tranzaction))
                {
                    MessageBox.Show("Tranzaction Created!");
                    contentPresenter.Content = new TranzactionsGridViewModel();
                }
                else
                    MessageBox.Show("Failed to create the tranzaction!");
            }

        }

        private void Check_Button_Click(object sender, RoutedEventArgs e)
        {
            if (contentPresenter.Content as BaseViewModel == null)
                return;

            BaseViewModel viewModel = contentPresenter.Content as BaseViewModel;
            if (viewModel.CheckData())
            {
                MessageBox.Show("Data format is valid.");

            }
            else
            {
                MessageBox.Show("Invalid data format!");
            }
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RibbonMenuItem;

            switch (button.Tag.ToString())
            {
                case "Client":
                    contentPresenter.Content = new EditClientViewModel(new Client());
                    break;

                case "Account":
                    contentPresenter.Content = new CreateAccountViewModel();
                    break;

                case "AccountOffer":
                    contentPresenter.Content = new EditAccountOfferViewModel(new AccountOffer());
                    break;

                case "Transaction":
                    contentPresenter.Content = new CreateTranzactionViewModel();
                    break;

                default:
                    break;
            }
        }

        private void Go_Back_Button_Click(object sender, RoutedEventArgs e)
        {

                contentPresenter.Content = null;
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {

            switch (contentPresenter.Content)
            {
                case EditClientViewModel _:
                    contentPresenter.Content = new EditClientViewModel(new Client());
                    break;

                case EditAccountViewModel _:
                    contentPresenter.Content = new EditAccountViewModel(new Account());
                    break;

                case EditAccountOfferViewModel _:
                    contentPresenter.Content = new EditAccountOfferViewModel(new AccountOffer());
                    break;

                case CreateAccountViewModel _:
                    contentPresenter.Content = new CreateAccountViewModel();
                    break;

                case CreateTranzactionViewModel _:
                    contentPresenter.Content = new CreateTranzactionViewModel();
                    break;

                default:
                    break;
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this instance?","Remove", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
                return;

            var selected = contentPresenter.Content as BaseViewModel;
            switch (selected)
            {
                case ClientsGridViewModel cg:
                    if(EditSecurityController.RemoveClient(cg.SelectedClient))
                        MessageBox.Show("Client Removed.");
                    else
                        MessageBox.Show("Failed to remove the client.");
                    contentPresenter.Content = new ClientsGridViewModel();
                    break;

                case AccountsGridViewModel ag:
                    if (EditSecurityController.RemoveAccount(ag.SelectedAccount))
                        MessageBox.Show("Account Removed.");
                    else
                        MessageBox.Show("Failed to remove the account.");
                    contentPresenter.Content = new AccountsGridViewModel();
                    break;

                case AccountOffersGridViewModel aog:
                    if (EditSecurityController.RemoveAccountOffer(aog.SelectedAccountOffer))
                        MessageBox.Show("Account Offer Removed.");
                    else
                        MessageBox.Show("Failed to remove the account offer.");
                    contentPresenter.Content = new AccountOffersGridViewModel();
                    break;

                default:
                    break;
            }
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
