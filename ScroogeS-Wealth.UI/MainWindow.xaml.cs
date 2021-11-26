using ScroogeS_Wealth.Business;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> _users;
        public MainWindow()
        {
            InitializeComponent();
            GenericStorage<User> users = new GenericStorage<User>();
            _users = new ObservableCollection<User>(users.Get());
            usersComboBox.ItemsSource = _users;
        }

        private void Button_AddUser_Click(object sender, RoutedEventArgs e)
        {
            string userName = userNameBox.Text.Trim();
            CheckInput(userName);

            if (userName != "" && CheckForSameName(userName) == false)
            {
                UserLogic user = new UserLogic();
                user.CreateUser(userName);
                User userToAdd = new User(userName);
                _users.Add(userToAdd);
                MessageBox.Show("Пользователь успешно добавлен! =)");
            }
        }

        private void Button_DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)usersComboBox.SelectedItem;
            _users.Remove(user);
            int id = user.Id;
            MessageBox.Show($"Пользователь {user.Name} удален!");
            UserLogic userToDelete = new UserLogic();
           // userToDelete.RemoveUser(id);
        }

        private bool CheckForSameName(string name)
        {
            foreach (var user in _users)
            {
                if (name == user.Name)
                {
                    return true;
                }
            }
            return false;
        }

        private void CheckInput(string stringToCheck)
        {
            if (CheckForSameName(stringToCheck) == true)
            {
                userNameBox.ToolTip = "Пользователь с таким именем уже существует";
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
                userNameBox.Background = Brushes.Transparent;
            }
        }

        private void Button_DeleteData_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
