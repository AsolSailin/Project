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
    /// Логика взаимодействия для ZooengineerWindow.xaml
    /// </summary>
    public partial class ZooengineerWindow : Window
    {
        public ZooengineerWindow()
        {
            InitializeComponent();
            ListAviary.ItemsSource = App.Connection.Aviary.ToList();
            ListAnimal.ItemsSource = App.Connection.Animal.ToList();
        }

        private void FeedingBtn_Click(object sender, RoutedEventArgs e)
        {
            FeedingWindow feedingWindow = new FeedingWindow();
            feedingWindow.Show();
            this.Close();
        }

        private void CleaningBtn_Click(object sender, RoutedEventArgs e)
        {
            CleaningWindow cleaningWindow = new CleaningWindow();
            cleaningWindow.Show();
            this.Close();
        }

        private void VeterinaryBtn_Click(object sender, RoutedEventArgs e)
        {
            VeterinaryWindow veterinaryWindow = new VeterinaryWindow();
            veterinaryWindow.Show();
            this.Close();
        }

        private void CoolingBtn_Click(object sender, RoutedEventArgs e)
        {
            CoolingWindow coolingWindow = new CoolingWindow();
            coolingWindow.Show();
            this.Close();
        }
    }
}
