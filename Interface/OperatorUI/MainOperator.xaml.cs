using ClientLib.Operator.Controllers;
using Database;
using Interface.OperatorUI.ViewModels;
using System.Windows;
using Telerik.Windows.Controls;
using System.Windows.Media;
using Interface.OperatorUI.ViewModels.Edit;
using System.Windows.Controls.Ribbon;
using Interface.OperatorUI.ViewModels.Create;
//using System.Windows.Media;

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

            StyleManager.ApplicationTheme = new Office_BlueTheme();
            System.Windows.Media.Brush myBrush = new SolidColorBrush(Colors.Transparent);

            gridView = new RadGridView
            {
                ShowGroupPanel = false,
                FontSize = 24,
                Background = myBrush
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
            else
            if (gridView.SelectedItem is Account)
                contentPresenter.Content = new EditAccountViewModel(gridView.SelectedItem as Account);

            gridView.SelectedItem = null;
        }

        private void Save_button_Click(object sender, RoutedEventArgs e)
        {

            if(contentPresenter.Content is EditClientViewModel)
            {
                var viewModel = contentPresenter.DataContext as EditClientViewModel;
                viewModel.Trim();
                if (EditSecurityController.UpdateClient(viewModel.Client))
                {
                    MessageBox.Show("Client Updated!");
                    gridView.ItemsSource = GridController.GetAllClients();
                    contentPresenter.Content = gridView;
                }
            }
        }

        private void Check_Button_Click(object sender, RoutedEventArgs e)
        {
            if(contentPresenter.Content is EditClientViewModel)
            {
                var viewModel = contentPresenter.Content as EditClientViewModel;
                if (EditSecurityController.CanUpdateClient(viewModel.Client))
                {
                    
                }

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
                    break;

                default:
                    break;
            }
        }

        private void Go_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            if (contentPresenter.Content is BaseViewModel)
                contentPresenter.Content = gridView;
            else
            if (contentPresenter.Content == gridView)
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

                default:
                    break;
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this instance?","Remove", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
                return;

            if (gridView.SelectedItem is Client)
            {
                if (EditSecurityController.RemoveClient(gridView.SelectedItem as Client))
                    MessageBox.Show("Client Removed.");
                else
                    MessageBox.Show("Failed to remove the client.");

                gridView.ItemsSource = GridController.GetAllClients();
                contentPresenter.Content = gridView;
            }
            else
            if (gridView.SelectedItem is Account)
                EditSecurityController.RemoveAccount(gridView.SelectedItem as Account);
            else
            if (gridView.SelectedItem is AccountOffer)
                EditSecurityController.RemoveAccountOffer(gridView.SelectedItem as AccountOffer);
        }
    }
}
