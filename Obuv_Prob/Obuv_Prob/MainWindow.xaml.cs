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

            if (CurrentUser.Role_id == 3)
            {
                SortDesRB.Visibility = Visibility.Collapsed;
                SortRB.Visibility = Visibility.Collapsed;
                DelBtn.Visibility = Visibility.Collapsed;
            }
            if(CurrentUser.Role_id == 2)
            {
                DelBtn.Visibility = Visibility.Collapsed;
            }
        }

        //Поиск
        private void SearchTB_KeyDown(object sender, KeyEventArgs e)
        {
            string search = SearchTB.Text;

            List<Products> products = App.db.Products.Where(p => p.Product_Name.Contains(search)).ToList();
            ProductLB.ItemsSource = products;
        }
        //Сортировка
        private void SortRB_Checked(object sender, RoutedEventArgs e)
        {
            List<Products> products = App.db.Products.OrderBy(p => p.Product_Name).ToList();
            ProductLB.ItemsSource =products;    
        }
        //Сортировка
        private void SortDesRB_Checked(object sender, RoutedEventArgs e)
        {
            List<Products> products = App.db.Products.OrderByDescending(p => p.Product_Name).ToList();
            ProductLB.ItemsSource =products;
        }

        private void LoadData()
        {
            
            List<Products> products = App.db.Products.ToList();
            ProductLB.ItemsSource = products;
        }
      
        private void ManufaturerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var slectedProduct = ProductLB.SelectedItem as Products;
            if (slectedProduct == null)
            {
                MessageBox.Show("Выбери товар!", "Ошибка",MessageBoxButton.OK);
                return;
            }
            App.db.Products.Remove(slectedProduct);
            App.db.SaveChanges();
            LoadData();
        }
    }
}
