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
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace WPFAuthorizationWithMongo
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private User user;
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            user.Name = tbName.Text;
            user.Surname = tbSurname.Text;
            user.BirthDate = tbBirthDate.Text;
            user.Login = tbLogin.Text;
            user.Password = tbPassword.Text;
            user.PasswordRepeat = tbPasswordRepeat.Text;
            DataBase.AddUserToDataBase(user);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show(); ;
            this.Close();
        }
    }
}
