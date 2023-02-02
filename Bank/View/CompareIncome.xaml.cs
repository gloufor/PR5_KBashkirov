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

namespace Bank.View
{
    /// <summary>
    /// Interaction logic for CompareIncome.xaml
    /// </summary>
    public partial class CompareIncome : Window
    {
        public CompareIncome(List<Deposit> depositList)
        {
            InitializeComponent();
            planeDataGrid.ItemsSource = depositList;
           
        }

      

        private void openDeposit_Click(object sender, RoutedEventArgs e)
        {
            var selectedDeposit = planeDataGrid.SelectedItem as Deposit;
            if (selectedDeposit != null)
            {
                View.AuthorizationWindow authorizationWindow = new View.AuthorizationWindow(selectedDeposit);
                authorizationWindow.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "Print");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
