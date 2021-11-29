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
    /// Interaction logic for CashTab.xaml
    /// </summary>
    public partial class CashTab : UserControl
    {
        private ObservableCollection<User> _users;
        private ObservableCollection<Cash> _cashes;
        private MainWindow _mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        public CashTab()
        {
            InitializeComponent();
            _users = _mainWindow.GetUserList();
            usersComboBox.ItemsSource = _users;
        }
        private void Button_AddCard_Click(object sender, RoutedEventArgs e)
        {
            GenericStorage<Cash> cashes = new GenericStorage<Cash>();
            _cashes = new ObservableCollection<Cash>(cashes.Get());
            string cashName = cashNameBox.Text.Trim();
            CheckInputName(cashName);
            decimal balance = 0;

            if (CheckInputDecimal(cashBalanceBox))
            {
                balance = Convert.ToDecimal(cashBalanceBox.Text);
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

            if (cashName != "" && CheckAccountsForSameName(cashName) == false
                && balance != 0 && user != null)
            {
                CashStorage cashStorage = new CashStorage();
                cashStorage.Create(cashName, balance, userId);
                MessageBox.Show($"копилка добавлена пользователю {user.Name}!=)");
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
                cashNameBox.ToolTip = "Это имя уже занято";
                cashNameBox.Background = Brushes.Red;
            }
            else if (accountName == "")
            {
                cashNameBox.ToolTip = "Это поле нельзя оставлять пустым";
                cashNameBox.Background = Brushes.Red;
            }
            else
            {
                cashNameBox.ToolTip = "";
                cashNameBox.Background = Brushes.White;
            }
        }

        private bool CheckAccountsForSameName(string accountName)
        {
            foreach (var cash in _cashes)
            {
                if (accountName == cash.Name)
                {
                    return true;
                }
            }
            return false;
        }

    } }
