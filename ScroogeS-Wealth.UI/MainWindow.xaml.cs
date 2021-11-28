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
        private ObservableCollection<Deposit> _deposits;
        private ObservableCollection<Card> _cards;
        private ObservableCollection<Account> _accounts;
        private ObservableCollection<Cash> _cash;

        public MainWindow()
        {
            InitializeComponent();
            usersComboBox.ItemsSource = _users;
        }

        public ObservableCollection<User> GetUserList()
        {
            GenericStorage<User> users = new GenericStorage<User>();
            _users = new ObservableCollection<User>(users.Get());
            return _users;
        }

        private void Button_AddUser_Click(object sender, RoutedEventArgs e)
        {
            string userName = userNameBox.Text.Trim(); 
            CheckInputData(userName);

            if (userName != "" && CheckUsersForSameName(userName) == false)
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
            userToDelete.RemoveUser(id);
            
        }

        private bool CheckUsersForSameName(string name)
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
