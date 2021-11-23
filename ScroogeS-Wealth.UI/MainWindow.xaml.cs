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

            if (userName != "")
            {
                UserLogic user = new UserLogic();
                user.CreateUser(userName);
                User user1 = new User(userName);
                _users.Add(user1);
                MessageBox.Show("Пользователь успешно добавлен! =)");
            }
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

        private void Button_DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        
    }
}
