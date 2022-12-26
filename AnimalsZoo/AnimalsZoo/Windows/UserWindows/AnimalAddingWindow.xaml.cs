using Microsoft.Win32;
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
using System.IO;
using AnimalsZoo.ADOApp;
using System.Data;

namespace AnimalsZoo.Windows.UserWindows
{
    /// <summary>
    /// Логика взаимодействия для AnimalAddingWindow.xaml
    /// </summary>
    public partial class AnimalAddingWindow : Window
    {
        public byte[] Image { get; set; }
        public AnimalAddingWindow()
        {
            InitializeComponent();
            var kinds = App.Connection.AnimalKind.ToList();
            foreach (var item in kinds)
            {
                KindComboBox.Items.Add(item);
            }
            var aviaries = App.Connection.Aviary.ToList();
            foreach (var item in aviaries)
            {
                AviaryComboBox.Items.Add(item);
            }
        }

        private void PhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog() != null)
                {
                    Image = File.ReadAllBytes(dialog.FileName);
                }
                btn.Content = "PHOTO SELECTED";
                btn.Background = new SolidColorBrush(Color.FromArgb(1, 179, 255, 229));
                btn.IsEnabled = false;
            }
            catch
            {
                MessageBox.Show("Only images!");
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != "" && KindComboBox.Text != "" && AviaryComboBox.Text != "" && Image != null)
            {
                var kind = KindComboBox.SelectedItem as AnimalKind;
                var aviary = AviaryComboBox.SelectedItem as Aviary;

                int condition;
                if (aviary.Type_Id == 2)
                {
                    condition = 2;
                }
                else
                {
                    condition = 1;
                }

                var newAnimal = new Animal()
                {
                    Name = tbName.Text,
                    Kind_Id = kind.Id,
                    Aviary_Id = aviary.Id,
                    Condition_Id = condition,
                    Image = Image
                };

                App.Connection.Animal.Add(newAnimal);
                App.Connection.SaveChanges();
                MessageBox.Show("The animal has been added to the zoo");
            }
            else
            {
                MessageBox.Show("Error in the data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MoreBtn_Click(object sender, RoutedEventArgs e)
        {
            AnimalAddingWindow animalAddingWindow = new AnimalAddingWindow();
            animalAddingWindow.Show();
            this.Close();
        }
    }
}
