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
    /// Interaction logic for W_Recipes.xaml
    /// </summary>
    public partial class W_Recipes : Window
    {
        public static ObservableCollection<Recipe> recipes;

        public W_Recipes()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //recipes = GenerateRecipes(10);
            //MyStorage.WriteXML<ObservableCollection<Recipe>>(recipes, "recipes.xml");
            recipes = MyStorage.ReadXml<ObservableCollection<Recipe>>("recipes.xml");
            if (recipes != null)
            {
                Lbx_recipes.ItemsSource = recipes;
            }
            else
                Lbx_recipes.ItemsSource = recipes;
        }

        //private ObservableCollection<Recipe> GenerateRecipes(int cnt)
        //{
        //    var lst = new ObservableCollection<Recipe>();
        //    for (int i = 0; i < cnt; i++)
        //    {
        //        lst.Add(new Recipe { productName = "Vollkorn Brot", totalCost = 10, bakingTime = 120, prepTime = 60, recipeProcess = "enfjsdcnklasncfladkfnakfnmkmldsf", totalTime = 180 });
        //    }
        //    return lst;
        //}

            private void Btn_addRecipes_Click(object sender, RoutedEventArgs e)
        {
            var recp = new Recipe { productName = "edit", totalCost = 0, bakingTime = 0, prepTime = 0, recipeProcess ="edit", totalTime =0 };
            recipes.Add(recp);
            Lbx_recipes.SelectedItem = recp;
            Lbx_recipes.ScrollIntoView(recp);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MyStorage.WriteXML<ObservableCollection<Recipe>>(recipes,"recipes.xml");

        }

        private void Btn_testIngredientsClick(object sender, RoutedEventArgs e)
        {
            var win = new W_Ingredients();
            win.Owner = this;
            win.Show();
        }
    }
}
