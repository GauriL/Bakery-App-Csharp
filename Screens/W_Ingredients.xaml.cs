using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Wpf_BakeryManagement
{
    /// <summary>
    /// Interaction logic for W_Ingredients.xaml
    /// </summary>
    public partial class W_Ingredients : Window
    {
        public W_Ingredients()
        {
            InitializeComponent();
        }
        public static ObservableCollection<Ingredients> _lessingredient = new ObservableCollection<Ingredients>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Lbx_ingredient.ItemsSource = App._ingredient;
            foreach (Ingredients i in App._ingredient)
            {
                if (i.minimum > i.available)
                {
                    _lessingredient.Add(i);
                }
            }
            Lbx_ingredients.ItemsSource = _lessingredient;
        }
        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = Tbx_filter.Text.ToLower();
            if (filter == "")
                Lbx_ingredient.ItemsSource = App._ingredient;
            else
            {
                var lst = from s in App._ingredient where s.name.ToLower().Contains(filter) select s;
                Lbx_ingredient.ItemsSource = lst;

            }
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var ingr = new Ingredients { name = "2 be edited", available = 0, minimum = 0, cost = 0 };
            App._ingredient.Add(ingr);
            Lbx_ingredient.SelectedItem = ingr;
            Lbx_ingredient.ScrollIntoView(ingr);
        }
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = Lbx_ingredient.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please select an item", "Error");
                return;
            }
            App._ingredient.Remove(item as Ingredients);
        }
    }
}
