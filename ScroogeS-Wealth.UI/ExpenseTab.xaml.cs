using ScroogeS_Wealth.Business.HelpersStorage;
using ScroogeS_Wealth.Models;
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

namespace ScroogeS_Wealth.UI
{
    /// <summary>
    /// Interaction logic for ExpenseTab.xaml
    /// </summary>
    public partial class ExpenseTab : UserControl
    {
        public ExpenseTab()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridUserInfo.Items.Clear();
            User user = (User)usersComboBox.SelectedItem;

            if (user.Cards.Count != 0)
            {
                DataGridUserInfo.Items.Add(user.Cards);
            }

            if (user.Accounts.Count != 0)
            {
                DataGridUserInfo.Items.Add(user.Accounts);
            }

            if (user.Cash.Count != 0)
            {
                DataGridUserInfo.Items.Add(user.Cash);
            }

            if (user.Deposits.Count != 0)
            {
                DataGridUserInfo.Items.Add(user.Deposits);
            }
        }

        private void Button_AddUser_Click(object sender, RoutedEventArgs e)
        {
            string userName = userNameBox.Text.Trim();
            CheckInputData(userName);

            if (userName != "" && CheckUsersForSameName(userName) == false)
            {
                UserStorage user = new UserStorage();
                User userToAdd = user.CreateUser(userName).Body;
                //_users.Add(userToAdd);
                MessageBox.Show("Пользователь успешно добавлен! =)");
            }
        }

        private void Button_DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)usersComboBox.SelectedItem;
            int userId = user.Id;
            //_users.Remove(user);
            UserStorage userStorage = new UserStorage();
            userStorage.Remove(userId);
            MessageBox.Show($"Пользователь {user.Name} удален!");
        }

        private bool CheckUsersForSameName(string name)
        {
            //foreach (var user in _users)
            //{
            //    if (name == user.Name)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        private void CheckInputData(string stringToCheck)
        {
            if (CheckUsersForSameName(stringToCheck))
            {
                userNameBox.ToolTip = "Это имя уже занято";
                userNameBox.Background = Brushes.Red;
            }
            else if (stringToCheck == "")
            {
                userNameBox.ToolTip = "Это поле нельзя оставлять пустым";
                userNameBox.Background = Brushes.Red;
            }
            else
            {
                userNameBox.ToolTip = "";
                userNameBox.Background = Brushes.White;
            }
        }

        private void Button_DeleteData_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
