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
