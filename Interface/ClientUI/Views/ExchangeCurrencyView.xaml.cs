using Interface.ClientUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using Telerik.Windows.Controls.Charting;

namespace Interface.ClientUI.Views
{
    /// <summary>
    /// Interaction logic for ExchangeCurrencyView.xaml
    /// </summary>
    public partial class ExchangeCurrencyView : UserControl
    {
        public List<string> monthsList;
        public ExchangeCurrencyView()
        {
            InitializeComponent();

            //Axis Data formatting
            radChart.DefaultView.ChartArea.AxisX.AutoRange = true;
            radChart.DefaultView.ChartArea.AxisX.LabelRotationAngle = 45;
            radChart.DefaultView.ChartArea.AxisX.DefaultLabelFormat = "dd-MMM";
            radChart.DefaultView.ChartArea.AxisY.DefaultLabelFormat = "#VAL{C3}";

            //Chart Title
            radChart.DefaultView.ChartTitle.Content = "Exchange currencies for 2021";

            //Legend - Combobox
            radChart.DefaultView.ChartLegend.MinWidth = months_combobox.MinWidth + 10;

            //Init Months
            monthsList = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                monthsList.Add(CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[i]);
            }
            months_combobox.ItemsSource = monthsList;
            months_combobox.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void ChartView_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataContext as ExchangeCurrencyViewModel != null)
            {
                int month = DateTime.ParseExact(months_combobox.Text, "MMMM", CultureInfo.CurrentCulture).Month;
                (DataContext as ExchangeCurrencyViewModel).UpdateMonthList(month);
                radChart.ItemsSource = (DataContext as ExchangeCurrencyViewModel).CurrencyMonthList;
            }

            if(months_combobox.Text == "Year")
            {
                radChart.ItemsSource = (DataContext as ExchangeCurrencyViewModel).CurrencyYearList;

                radChart.DefaultView.ChartTitle.Content = "Exchange currencies for " + DateTime.Now.Year;
            }

            else
            if(months_combobox.Text == "Month")
            {
                radChart.ItemsSource = (DataContext as ExchangeCurrencyViewModel).CurrencyMonthList;

                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
                radChart.DefaultView.ChartTitle.Content = "Exchange currencies for " + monthName;
            }
        }

        private void Amount_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(DataContext is ExchangeCurrencyViewModel)
                result_box.Text = (DataContext as ExchangeCurrencyViewModel).Ron.ToString();
        }

        private void Year_button_Click(object sender, RoutedEventArgs e)
        {
            if(DataContext is ExchangeCurrencyViewModel)
            {
                radChart.ItemsSource = (DataContext as ExchangeCurrencyViewModel).CurrencyYearList;
                radChart.DefaultView.ChartTitle.Content = "Exchange currencies for " + DateTime.Now.Year;
            }
        }
    }
}
