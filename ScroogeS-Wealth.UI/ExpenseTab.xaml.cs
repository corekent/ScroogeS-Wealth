using ScroogeS_Wealth.Business.HelpersStorage;
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
    /// Interaction logic for ExpenseTab.xaml
    /// </summary>
    public partial class ExpenseTab : UserControl
    {
        private ObservableCollection<User> _users;
        private ObservableCollection<Expense> _expenses;
        private MainWindow _mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        public ExpenseTab()
        {
            InitializeComponent();
            DataGridUserInfo.ItemsSource = _expenses;
            _users = _mainWindow.GetUserList();
            usersComboBox.ItemsSource = _users;
        }

        private void Button_AddUser_Click(object sender, RoutedEventArgs e)
        {
            string expenseName = expenseNameBox.Text.Trim();
            var user = usersComboBox.SelectedItem;

            if (expenseName != "")
            {
                //ExpenseStorage<, Expense> expenseStorage = new ExpenseStorage<,Expense>();
                //User userToAdd = user.CreateUser(expenseName).Body;
                ////_users.Add(userToAdd);
                //MessageBox.Show("Пользователь успешно добавлен! =)");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        private void Button_DeleteData_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
