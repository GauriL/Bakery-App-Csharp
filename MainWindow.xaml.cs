using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Resources;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ComboBox = System.Windows.Controls.ComboBox;


namespace Wpf_BakeryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public static ObservableCollection<Customer> customers;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            customers = MyStorage.ReadXml<ObservableCollection<Customer>>("customers.xml");
            if (customers != null)
            {
                Lbx_listOfShopnames.ItemsSource = customers;
            }
            else
                Lbx_listOfShopnames.ItemsSource = customers;

            Cbx_modesOfOrder.ItemsSource = new List<string> { "On Call", "By Email", "By Fax" };
        }

        private void Btn_addShopname_Click(object sender, RoutedEventArgs e)
        {
            var cstmr = new Customer { shopName = "to be edited", customerName = "to be edited", personOrdering = "Edit", billingAddress="edit", deliveryAddress="edit",emailAddress="edit", modeOfOrder="edit",telephoneNumber=0};
            customers.Add(cstmr);
            Lbx_listOfShopnames.SelectedItem = cstmr;
            Lbx_listOfShopnames.ScrollIntoView(cstmr);
        }
        private void Btn_createOrder_Click(object sender, RoutedEventArgs e)
        {
            var win = new W_Products();
            win.Owner = this;
            win.Show();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MyStorage.WriteXML<ObservableCollection<Customer>>(customers, "customers.xml");
        }

        private void Btn_TestRecipes_Click(object sender, RoutedEventArgs e)
        {
            var win = new W_Recipes();
            win.Owner = this;
            win.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
