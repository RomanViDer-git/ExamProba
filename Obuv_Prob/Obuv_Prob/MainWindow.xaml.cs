using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
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

namespace Obuv_Prob
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Users CurrentUser { get; set; }
        private List<Products> _allProducts;
        public MainWindow(Users authUsers)
        {
            
            InitializeComponent();
            List<Products> products = App.db.Products.ToList();
            ProductLB.ItemsSource = products;
            List<Order> orders = App.db.Order.ToList();
            ProductDG.ItemsSource = orders;

            
            CurrentUser = authUsers;
            this.DataContext = this;

            LoadData();
        }

        //Поиск
        private void SearchTB_KeyDown(object sender, KeyEventArgs e)
        {
            string search = SearchTB.Text;

            List<Products> products = App.db.Products.Where(p => p.Product_Name.Contains(search)).ToList();
            ProductLB.ItemsSource = products;
        }

        private void SortRB_Checked(object sender, RoutedEventArgs e)
        {
            List<Products> products = App.db.Products.OrderBy(p => p.Product_Name).ToList();
            ProductLB.ItemsSource =products;    
        }

        private void SortDesRB_Checked(object sender, RoutedEventArgs e)
        {
            List<Products> products = App.db.Products.OrderByDescending(p => p.Product_Name).ToList();
            ProductLB.ItemsSource =products;
        }

        private void LoadData()
        {
            _allProducts = App.db.Products.ToList();
            ProductLB.ItemsSource = _allProducts;
            var manufacturesFromDb = App.db.Manufactures.ToList();
            List<string> comboItems = new List<string>();
            comboItems.Add("Все производители");
            foreach (var man in manufacturesFromDb)
            {
                comboItems.Add(man.Manufacturer_Name);   
            }
            ManufaturerCB.ItemsSource = comboItems;
            ManufaturerCB.SelectedIndex = 0;
        }

        private void ManufaturerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ManufaturerCB.SelectedItem == null) return;
            string selectedManufacturer = ManufaturerCB.SelectedItem.ToString();
            if (selectedManufacturer == "Все производители")
            {
                ProductLB.ItemsSource = _allProducts;
            }
            else
            {
                var filteredList = _allProducts.Where(p => p.Manufactures != null && p.Manufactures.Manufacturer_Name == selectedManufacturer).ToList();
                ProductLB.ItemsSource = filteredList;
            }
            
        }
    }
}
