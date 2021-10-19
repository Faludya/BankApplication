using ClientLib;
using ClientLib.Controllers;
using Interface.ClientUI;
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
using Telerik.Windows.Controls;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            //Hide();
            //MainClient mainClientWindow = new MainClient(1);
            //mainClientWindow.Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int validationResult = LoginController.IsLoginDataValid(usernameBox.Text, passwordBox.Password);

            if (validationResult > -1)
            {
                Hide();
                MainClient mainClientWindow = new MainClient(validationResult);
                mainClientWindow.Show();
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }
    }
}
