using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_BakeryManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private void Application_Startup(object sender, StartupEventArgs e)
        //{
        //    //_customers = GenerateCustomers(10);
        //    //MyStorage.WriteXML<ObservableCollection<Customer>>(App._customers, "customers.xml");
           
        //}

        //private ObservableCollection<Customer> GenerateCustomers(int cnt)
        //{
        //    var lst = new ObservableCollection<Customer>();
        //    for (int i = 0; i < cnt; i++)
        //    {               
        //        lst.Add(new Customer { shopName = "Shop name", customerName = "Firstname Lastname", telephoneNumber =0123456789, emailAddress="abc@gmail.com", personOrdering ="FirstName LastName", billingAddress="abc schweizertalstr", deliveryAddress= "abc schweizertalstr", modeOfOrder="email" });
        //    }
        //    return lst;
        //}

        public static ObservableCollection<Ingredients> _ingredient;
        Random rnd = new Random();

        private void Application_Startup(object sender, StartupEventArgs e)
        {

            //_ingredient = GenerateIngredients(20);
            _ingredient = MyStorage.ReadXml<ObservableCollection<Ingredients>>("raw_ingredients.xml");
            if (_ingredient == null)
                _ingredient = new ObservableCollection<Ingredients>();
        }

        private ObservableCollection<Ingredients> GenerateIngredients(int cnt)
        {
            var lst = new ObservableCollection<Ingredients>();
            for (int i = 0; i < cnt; i++)
            {
                var gndr = rnd.Next(3);
                lst.Add(new Ingredients { name = "I" + i, available = 0, minimum = 0, cost = 0 });
            }
            return lst;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            MyStorage.WriteXML<ObservableCollection<Ingredients>>(App._ingredient, "raw_ingredients.xml");
        }
    }
}
