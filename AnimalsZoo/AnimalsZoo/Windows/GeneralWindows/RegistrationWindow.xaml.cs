﻿using AnimalsZoo.ADOApp;
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

namespace AnimalsZoo.Windows.GeneralWindows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            var role = App.Connection.Role.ToList();
            foreach (var item in role)
            {
                RoleComboBox.Items.Add(item);
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            var role = RoleComboBox.SelectedItem as Role;

            if (tbLogin.Text != "" && tbPassword.Text != "" && tbName.Text != "" && RoleComboBox.Text != "")
            {
                User newUser = new User()
                {
                    Name = tbName.Text,
                    Role_Id = role.Id
                };
                Account newAccount = new Account()
                {
                    Login = tbLogin.Text,
                    Password = tbPassword.Text
                };

                newUser.Account.Add(newAccount);
                App.Connection.User.Add(newUser);
                App.Connection.Account.Add(newAccount);
                App.Connection.SaveChanges();
                MessageBox.Show("Registration is successfull");
            }
            else
            {
                MessageBox.Show("Incorrect data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show(); ;
            this.Close();
        }
    }
}
