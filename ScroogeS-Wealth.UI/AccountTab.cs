using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.UI
{
    class AccountTab
    {
        private ObservableCollection<User> _users;
        private ObservableCollection<Account> _accounts;
        private MainWindow _mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;

        public AccountTab()
        {
            InitializeComponent();
            _users = _mainWindow.GetUserList();
            usersComboBox.ItemsSource = _users;
        }

        private void Button_AddAccount_Click(object sender, RoutedEventArgs e)
        {
            GenericStorage<Account> accounts = new GenericStorage<Account>();
            _accounts = new ObservableCollection<Account>(accounts.Get());
            string accountName = accountNameBox.Text.Trim();
            CheckInputName(accountName);
            decimal balance = 0;

            if (CheckInputDecimal(accountBalanceBox))
            {
                balance = Convert.ToDecimal(accountBalanceBox.Text);
            }
            User user = (User)(usersComboBox.SelectedItem);
            int userId = 0;

            if (user is null)
            {
                MessageBox.Show("Выберите пользователя!");
            }
            else
            {
                userId = user.Id;
            }

            if (accountName != "" && CheckAccountsForSameName(accountName) == false && balance != 0 && user != null)
            {
                //DepositLogic deposit = new DepositLogic();
                //deposit.Create(depositName, balance, 1);
            }
        }

        private bool CheckInputDecimal(TextBox input)
        {
            if (decimal.TryParse(input.Text, out _))
            {
                input.ToolTip = "";
                input.Background = Brushes.White;
                return true;
            }
            else
            {
                input.ToolTip = "Это поле введено некорректно";
                input.Background = Brushes.Red;
                return false;
            }
        }

        private void CheckInputName(string accountName)
        {
            if (CheckAccountsForSameName(accountName))
            {
                accountNameBox.ToolTip = "Это имя уже занято";
                accountNameBox.Background = Brushes.Red;
            }
            else if (accountName == "")
            {
                accountNameBox.ToolTip = "Это поле нельзя оставлять пустым";
                accountNameBox.Background = Brushes.Red;
            }
            else
            {
                accountNameBox.ToolTip = "";
                accountNameBox.Background = Brushes.White;
            }
        }

        private bool CheckAccountsForSameName(string accountName)
        {
            foreach (var deposit in _accounts)
            {
                if (accountName == deposit.Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
