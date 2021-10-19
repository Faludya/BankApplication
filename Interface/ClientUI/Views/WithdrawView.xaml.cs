using ClientLib.Controllers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Interface.ClientUI.Views
{
    /// <summary>
    /// Interaction logic for WithdrawView.xaml
    /// </summary>
    public partial class WithdrawView : UserControl
    {
        public WithdrawView()
        {
            InitializeComponent();
        }

        private void Withdraw_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal withdrawAmount = decimal.Parse(amount_box.Text);

                if (iban_combobox.SelectedIndex != -1 && currency_combobox.SelectedIndex != -1 && withdrawAmount > 0)
                {
                    if(AccountsController.Withdraw(iban_combobox.Text, withdrawAmount, account_currency.Text, currency_combobox.Text))
                    {
                        MessageBox.Show("The sum was withdrawn from your account!");
                    }
                    else
                    {
                        error_text.Text = "Incorrect data or insuficient fonds!";
                    }
                }

            }
            catch (FormatException)
            {
                error_text.Text = "The number introduced was invaldi!";
                return;
            }
        }
    }
}
