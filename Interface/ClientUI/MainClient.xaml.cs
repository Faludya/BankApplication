using ClientLib.Controllers;
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
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Interface.ClientUI
{
    /// <summary>
    /// Interaction logic for MainClient.xaml
    /// </summary>
    public partial class MainClient : Window
    {
        private int clientId;
        public MainClient(int id)
        {
            InitializeComponent();

            clientId = id;
            DataContext = new MainViewModel();
            InitializeTree();
        }

        private void InitializeTree()
        {
            RadTreeViewItem viewAccounts = new RadTreeViewItem();
            viewAccounts.Header = "Accounts";
            viewAccounts.Tag = "Accounts";

            RadTreeViewItem deposit = new RadTreeViewItem();
            deposit.Header = "Deposit";
            deposit.Tag = "Deposit";

            RadTreeViewItem withdraw = new RadTreeViewItem();
            withdraw.Header = "Withdraw";
            withdraw.Tag = "Withdraw";

            RadTreeViewItem changePIN = new RadTreeViewItem();
            changePIN.Header = "Change PIN";
            changePIN.Tag = "Change PIN";

            tree.Items.Add(viewAccounts);
            tree.Items.Add(deposit);
            tree.Items.Add(withdraw);
            tree.Items.Add(changePIN);
        }


        private void Tree_ItemDoubleClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            var selectedItem = ((RadTreeViewItem)tree.SelectedItem).Tag.ToString();

            switch (selectedItem)
            {
                case "Accounts":
                    AccountsViewModel viewModel = new AccountsViewModel(clientId);
                    contentPresenter.Content = viewModel;
                   // contentPresenter.Content = gridView;

                    break;

                case "Deposit":
                    var res = LoginController.IsLoginDataValid("", "");
                    DepositViewModel depositViewModel = new DepositViewModel(clientId);
                    contentPresenter.Content = depositViewModel;

                    break;

                case "Withdraw":

                    break;

                case "Change PIN":

                    break;

                default:
                    break;
            }
        }
    }
}
