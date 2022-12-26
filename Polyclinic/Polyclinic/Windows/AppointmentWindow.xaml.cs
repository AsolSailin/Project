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

namespace Polyclinic.Windows
{
    /// <summary>
    /// Логика взаимодействия для AppointmentWindow.xaml
    /// </summary>
    public partial class AppointmentWindow : Window
    {
        public AppointmentWindow()
        {
            InitializeComponent();
            Doctor.ItemsSource = App.Connection.Doctor.ToList();
        }

        private void Btn_Click1(object sender, RoutedEventArgs e)
        {
            if (tbDate.Text != "")
            {
                MessageBox.Show("Вы успешно записались на прием в нашей поликлинике ");
            }
            else
            {
                MessageBox.Show("Данные введены некорректно", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
