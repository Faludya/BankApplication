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

        private void confirm_pin_box_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if ( e.Command == ApplicationCommands.Copy ||
                 e.Command == ApplicationCommands.Cut ||
                 e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
