using ScroogeS_Wealth.Business;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Create_User_Click(object sender, RoutedEventArgs e)
        {
            string userName = userNameBox.Text.Trim();
            string cardName = cardNameBox.Text.Trim();
            int moneyAmount = Convert.ToInt32(moneyAmountBox.Text.Trim());

            if (userName == "")
            {
                userNameBox.ToolTip ="Это поле нельзя оставлять пустым";
                userNameBox.Background = Brushes.Red;
            }
            else if (moneyAmountBox.Text.Contains(" ") || moneyAmountBox.Text.Contains("?"))
            {
                moneyAmountBox.ToolTip = "Это поле введено некорректно";
                moneyAmountBox.Background = Brushes.Red;
            }
            else
            {
                userNameBox.ToolTip = "";
                userNameBox.Background = Brushes.Transparent;
                moneyAmountBox.ToolTip = "";
                moneyAmountBox.Background = Brushes.Transparent;

                UserLogic user = new UserLogic();
                user.CreateUser(userName);
                CardLogic card = new CardLogic();
                card.CreateCard(cardName, moneyAmount, UserStorage.Users.Last().Id);
                MessageBox.Show("Пользователь успешно добавлен =)");
            }

        }
    }
}
