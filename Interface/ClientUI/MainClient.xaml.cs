using ClientLib.Controllers;
using Interface.ClientUI.ViewModels;
using System.Collections.Generic;
using System.Windows;
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
            StyleManager.ApplicationTheme = new Office_BlueTheme();

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

            RadTreeViewItem exchangeCurrency = new RadTreeViewItem();
            exchangeCurrency.Header = "Currency";
            exchangeCurrency.Tag = "Currency";

            tree.Items.Add(viewAccounts);
            tree.Items.Add(deposit);
            tree.Items.Add(withdraw);
            tree.Items.Add(changePIN);
            tree.Items.Add(exchangeCurrency);
        }


        private void Tree_ItemDoubleClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            var selectedItem = ((RadTreeViewItem)tree.SelectedItem).Tag.ToString();

            switch (selectedItem)
            {
                case "Accounts":
                    AccountsViewModel viewModel = new AccountsViewModel(AccountsController.GetClientAccounts(clientId));
                    contentPresenter.Content = viewModel;
                    break;

                case "Deposit":
                    DepositViewModel depositViewModel = new DepositViewModel(AccountsController.GetClientAccounts(clientId));
                    contentPresenter.Content = depositViewModel;

                    break;

                case "Withdraw":
                    WithdrawViewModel withdrawViewModel = new WithdrawViewModel(AccountsController.GetClientAccounts(clientId));
                    contentPresenter.Content = withdrawViewModel;
                    break;

                case "Change PIN":
                    ChangePinViewModel changePinViewModel = new ChangePinViewModel();
                    contentPresenter.Content = changePinViewModel;
                    break;

                case "Currency":
                    ExchangeCurrencyViewModel currencyViewModel = new ExchangeCurrencyViewModel();
                    contentPresenter.Content = currencyViewModel;
                    break;

                default:
                    break;
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

        private void Withdraw_Button_Click(object sender, RoutedEventArgs e)
        {
            if (contentPresenter.Content is WithdrawViewModel)
            {
                WithdrawViewModel viewModel = contentPresenter.Content as WithdrawViewModel;

                if (AccountsController.Withdraw(viewModel.SelectedAccount, viewModel.WithdrawAmount, viewModel.SelectedCurrency))
                {
                    MessageBox.Show("Your withdraw was successfull!");
                    contentPresenter.Content = null;
                }
                else
                    MessageBox.Show("Failed to withdraw!");
            }
        }

        private void Deposit_Button_Click(object sender, RoutedEventArgs e)
        {
            if(contentPresenter.Content is DepositViewModel )
            {
                DepositViewModel viewModel = contentPresenter.Content as DepositViewModel;
                
                if (AccountsController.Deposit(viewModel.SelectedAccount, viewModel.DepositAmount, viewModel.SelectedCurrency))
                {
                    MessageBox.Show("Your deposit was successfull!");
                    contentPresenter.Content = null;
                }
                else
                    MessageBox.Show("Failed to deposit!");
            }
        }

        private void Change_PIN_Button_Click(object sender, RoutedEventArgs e)
        {
            if(contentPresenter.Content is ChangePinViewModel)
            {
                ChangePinViewModel viewModel = contentPresenter.Content as ChangePinViewModel;
                if (AccountsController.UpdateClientPin(clientId, viewModel.OldPin, viewModel.NewPin, viewModel.ConfirmPin))
                {
                    MessageBox.Show("PIN changed!");
                    contentPresenter.Content = null;
                }
                else
                    MessageBox.Show("Unable to change PIN");
            }
        }
        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            BaseViewModel viewModel = contentPresenter.Content as BaseViewModel;

            switch (viewModel)
            {
                case DepositViewModel dv:
                    contentPresenter.Content = new DepositViewModel(AccountsController.GetClientAccounts(clientId));
                    break;

                case WithdrawViewModel wv:
                    contentPresenter.Content = new WithdrawViewModel(AccountsController.GetClientAccounts(clientId));
                    break;

                case ChangePinViewModel cp:
                    contentPresenter.Content = new ChangePinViewModel();
                    break;

                case ExchangeCurrencyViewModel ec:
                    contentPresenter.Content = new ExchangeCurrencyViewModel();
                    break;

                default:
                    break;
            }
        }

        private void Go_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            contentPresenter.Content = null;
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
    }
}
