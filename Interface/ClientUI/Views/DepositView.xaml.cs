﻿using ClientLib.Controllers;
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
    /// Interaction logic for DepositView.xaml
    /// </summary>
    public partial class DepositView : UserControl
    {
        public DepositView()
        {
            InitializeComponent();
        }

        private void Deposit_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal withdrawAmount = decimal.Parse(amount_box.Text);

                if (iban_combobox.SelectedIndex != -1 && currency_combobox.SelectedIndex != -1 && withdrawAmount > 0)
                {
                    if (AccountsController.Deposit(iban_combobox.Text, withdrawAmount, account_currency.Text, currency_combobox.Text))
                    {
                        MessageBox.Show("The sum was deposited to your account!");
                    }
                    else
                    {
                        error_text.Text = "Incorrect data!";
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
