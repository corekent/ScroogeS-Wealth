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
    /// Interaction logic for CardTab.xaml
    /// </summary>

        public partial class CardTab : UserControl
        {
            private ObservableCollection<User> _users;
            private ObservableCollection<Card> _cards;
            private MainWindow _mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;

            public CardTab()
            {
                InitializeComponent();
                _users = _mainWindow.GetUserList();
                usersComboBox.ItemsSource = _users;
            }

            private void Button_AddCard_Click(object sender, RoutedEventArgs e)
            {
                GenericStorage<Card> cards = new GenericStorage<Card>();
                _cards = new ObservableCollection<Card>(cards.Get());
                string cardName = cardNameBox.Text.Trim();
                CheckInputName(cardName);
                decimal balance = 0;

                if (CheckInputDecimal(cardBalanceBox))
                {
                    balance = Convert.ToDecimal(cardBalanceBox.Text);
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

                if (cardName != "" && CheckAccountsForSameName(cardName) == false
                    && balance != 0 && user != null)
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
                    cardNameBox.ToolTip = "Это имя уже занято";
                    cardNameBox.Background = Brushes.Red;
                }
                else if (accountName == "")
                {
                    cardNameBox.ToolTip = "Это поле нельзя оставлять пустым";
                    cardNameBox.Background = Brushes.Red;
                }
                else
                {
                    cardNameBox.ToolTip = "";
                    cardNameBox.Background = Brushes.White;
                }
            }

            private bool CheckAccountsForSameName(string accountName)
            {
                foreach (var deposit in _cards)
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