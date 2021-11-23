using ScroogeS_Wealth.Business;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace ScroogeS_Wealth.UI
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void Button_CreateUser_Click(object sender, RoutedEventArgs e)
        {
            string userName = userNameBox.Text.Trim();
            CheckInput(userName);

            if (userName != "")
            {
                UserLogic user = new UserLogic();
                user.CreateUser(userName);
                MessageBox.Show("Пользователь успешно добавлен! =)");
            }
        }

        private void AddUserToMainWindow()
        {
            
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
        private void CheckInput(string stringToCheck)
        {
            if (stringToCheck == "")
            {
                userNameBox.ToolTip = "Это поле нельзя оставлять пустым";
                userNameBox.Background = Brushes.Red;
            }
            else
            {
                userNameBox.ToolTip = "";
                userNameBox.Background = Brushes.Transparent;
            }
        }
    }
}
