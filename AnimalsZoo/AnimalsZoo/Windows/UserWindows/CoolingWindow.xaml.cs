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
    /// Логика взаимодействия для CoolingWindow.xaml
    /// </summary>
    public partial class CoolingWindow : Window
    {
        public CoolingWindow()
        {
            InitializeComponent();
            ListAviary.ItemsSource = App.Connection.Aviary.Where(x => x.Type_Id == 2).ToList();

            ListMethod.ItemsSource = App.Connection.CoolingMethod.ToList();

            string daytime = string.Empty;

            if (DateTime.Now.Hour >= 0)
            {
                daytime = "Morning";
            }
            
            if (DateTime.Now.Hour >= 11)
            {
                daytime = "Afternoon";
            }
            
            if(DateTime.Now.Hour >= 17)
            {
                daytime = "Evening";
            }
            
            if (DateTime.Now.Hour >= 21)
            {
                daytime = "Night";
            }

            var temp = App.Connection.Temperature.FirstOrDefault(x => daytime == x.DayTime);
            tbTemp.Text = temp.Value.ToString();

        }

        private void CollingBtn_Click(object sender, RoutedEventArgs e)
        {
            var aviary = ListAviary.SelectedItem as Aviary;
            var method = ListMethod.SelectedItem as CoolingMethod;

            var tempMethod = new Temperature_Method()
            {
               Temperature_Id = aviary.Temperature_Id,
               Method_Id = method.Id
            };

            App.Connection.Temperature_Method.Add(tempMethod);
            App.Connection.SaveChanges();
            MessageBox.Show("Changes saved successfully!");
        }
    }
}
