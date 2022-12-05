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
    /// Логика взаимодействия для VeterinaryWindow.xaml
    /// </summary>
    public partial class VeterinaryWindow : Window
    {
        public VeterinaryWindow()
        {
            InitializeComponent();
            ListAviary.ItemsSource = App.Connection.Aviary.ToList();
            ListMaterial.ItemsSource = App.Connection.CareMaterial.ToList();
            tbDate.Text = DateTime.Today.ToString();
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            var aviary = ListAviary.SelectedItem as Aviary;
            ListAnimal.ItemsSource = App.Connection.Animal.Where(x => x.Aviary_Id == aviary.Id).ToList();
        }

        private void VetBtn_Click(object sender, RoutedEventArgs e)
        {
            var animal = ListAnimal.SelectedItem as Animal;
            var material = ListMaterial.SelectedItem as CareMaterial;

            var animalMaterial = new Animal_Material()
            {
                Animal_Id = animal.Id,
                Material_Id = material.Id
            };

            App.Connection.SaveChanges();
            MessageBox.Show("Changes saved successfully!");
        }
    }
}
