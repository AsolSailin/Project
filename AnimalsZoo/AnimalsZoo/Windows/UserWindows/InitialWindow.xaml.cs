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
    /// Логика взаимодействия для InitialWindow.xaml
    /// </summary>
    public partial class InitialWindow : Window
    {
        Account account;
        public InitialWindow(Account acc)
        {
            InitializeComponent();
            account = acc;
            ListAviary.ItemsSource = App.Connection.Aviary.ToList();
        }
        private void Select(object sender, SelectionChangedEventArgs e)
        {
            var aviary = ListAviary.SelectedItem as Aviary;
            ListAnimal.ItemsSource = App.Connection.Animal.Where(x => x.Aviary_Id == aviary.Id).ToList();
        }

        private void ManagementBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = App.Connection.User.Where(x => x.Id == account.User_Id).FirstOrDefault();
            switch (user.Role_Id)
            {
                case 1:
                    FeedingWindow feedingWindow = new FeedingWindow();
                    feedingWindow.Show();
                    this.Close();
                    break;
                case 2:
                    VeterinaryWindow veterinaryWindow = new VeterinaryWindow();
                    veterinaryWindow.Show();
                    this.Close();
                    break;
                case 3:
                    CoolingWindow coolingWindow = new CoolingWindow();
                    coolingWindow.Show();
                    this.Close();
                    break;
                case 4:
                    CleaningWindow cleaningWindow = new CleaningWindow();
                    cleaningWindow.Show();
                    this.Close();
                    break;
            }
        }
    }
}
