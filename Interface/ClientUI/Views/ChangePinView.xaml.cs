using ClientLib.Controllers;
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
    /// Interaction logic for ChangePinView.xaml
    /// </summary>
    public partial class ChangePinView : UserControl
    {
        public ChangePinView()
        {
            InitializeComponent();
        }

        private void Change_pin_button_Click(object sender, RoutedEventArgs e)
        {
            if(old_pin_box.Password == "" || new_pin_box.Password == "" || confirm_pin_box.Password == "")
            {
                error_text.Text = "All the fields are required.";
            }
            else
            if(new_pin_box.Password == confirm_pin_box.Password)
            {
                var res = change_pin_button.DataContext.ToString();
                int clientId =  Int32.Parse(change_pin_button.DataContext.ToString());
                if(AccountsController.UpdateClientPin(clientId,old_pin_box.Password, new_pin_box.Password))
                {
                    MessageBox.Show("Pin changed successfully!");
                }
                else
                {
                    error_text.Text = "Data was not valid.";
                }
            }
            else
            {
                error_text.Text = "The pins are not the same.";
            }
        }

        private void Clear_button_Click(object sender, RoutedEventArgs e)
        {
            old_pin_box.Password = new_pin_box.Password = confirm_pin_box.Password = error_text.Text = null;
        }
    }
}
