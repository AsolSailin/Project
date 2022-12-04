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
    /// Логика взаимодействия для CoolingWindow.xaml
    /// </summary>
    public partial class CoolingWindow : Window
    {
        public CoolingWindow()
        {
            InitializeComponent();
        }

        private void CollingBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ZooengineerWindow zooengineerWindow = new ZooengineerWindow();
            zooengineerWindow.Show();
            this.Close();
        }
    }
}
