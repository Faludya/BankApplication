using ClientLib.Controllers;
using Interface.OperatorUI;
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

namespace Interface
{
    /// <summary>
    /// Interaction logic for OperatorValidation.xaml
    /// </summary>
    public partial class OperatorValidation : Window
    {
        private MainWindow parent;
        public OperatorValidation(MainWindow mainWindow)
        {
            InitializeComponent();
            parent = mainWindow;
        }

        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Enter_button_Click(object sender, RoutedEventArgs e)
        {
            if (LoginController.IsVerificationRequestValid(code_box.Password))
            {
                this.Close();
                parent.Hide();
                MainOperator mainOperator = new MainOperator();
                mainOperator.Show();
            }
            else
            {
                code_box.BorderBrush = Brushes.Red;
                code_box.BorderThickness = new Thickness(1);
                error_message.Text = "Invalid data!";
            }
        }
    }
}
