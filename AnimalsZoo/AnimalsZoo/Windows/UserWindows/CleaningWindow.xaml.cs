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
    /// Логика взаимодействия для CleaningWindow.xaml
    /// </summary>
    public partial class CleaningWindow : Window
    {
        public CleaningWindow()
        {
            InitializeComponent();
            ListAviary.ItemsSource = App.Connection.Aviary.ToList();
            tbDate.Text = DateTime.Today.ToString("dd:MM:yyyy");
            App.dispatcherTimer.Tick += new EventHandler(RefreshAviary);
        }

        private void RefreshAviary(object sender, EventArgs e)
        {
            ListAviary.Items.Refresh();
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            var aviary = ListAviary.SelectedItem as Aviary;
            aviary.Cleaned = true;
            App.Connection.SaveChanges();
            ListAviary.Items.Refresh();
        }
    }
}
