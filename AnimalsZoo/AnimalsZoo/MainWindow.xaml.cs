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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AnimalsZoo.ADOApp;
using AnimalsZoo.Windows.GeneralWindows;
using AnimalsZoo.Windows.UserWindows;

namespace AnimalsZoo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            App.dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            App.dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            App.dispatcherTimer.Start();

            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            foreach (var item in App.Connection.Aviary)
            {
                item.Cleaned = false;
            }
            App.Connection.SaveChanges();
        }
    }
}
