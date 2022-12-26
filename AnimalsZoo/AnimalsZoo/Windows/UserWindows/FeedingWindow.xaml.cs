using AnimalsZoo.ADOApp;
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

namespace AnimalsZoo.Windows.UserWindows
{
    /// <summary>
    /// Логика взаимодействия для FeedingWindow.xaml
    /// </summary>
    public partial class FeedingWindow : Window
    {
        public FeedingWindow()
        {
            InitializeComponent();
            ListAviary.ItemsSource = App.Connection.Aviary.ToList();
            ListProduct.ItemsSource = App.Connection.Product.ToList();
            tbDate.Text = DateTime.Today.ToString("dd:MM:yyyy");
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            var aviary = ListAviary.SelectedItem as Aviary;
            ListAnimal.ItemsSource = App.Connection.Animal.Where(x => x.Aviary_Id == aviary.Id).ToList();
        }

        private void FeedingBtn_Click(object sender, RoutedEventArgs e)
        {
            var animal = ListAnimal.SelectedItem as Animal;
            var product = ListProduct.SelectedItem as Product;

            var animalProduct = new Animal_Product()
            {
                Animal_Id = animal.Id,
                Product_Id = product.Id
            };

            App.Connection.Animal_Product.Add(animalProduct);
            App.Connection.SaveChanges();
            MessageBox.Show("Changes saved successfully!");
        }
    }
}
