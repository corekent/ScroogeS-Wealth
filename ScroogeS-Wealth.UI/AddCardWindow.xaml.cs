using ScroogeS_Wealth.Business;
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
using System.Windows.Shapes;

namespace ScroogeS_Wealth.UI
{
    /// <summary>
    /// Interaction logic for AddCardWindow.xaml
    /// </summary>
    public partial class AddCardWindow : Window
    {
        public AddCardWindow()
        {
            InitializeComponent();
        }

        private void Button_CreateCard_Click(object sender, RoutedEventArgs e)
        {
            CheckInput(cardNameBox.Text, balanceBox.Text);
            string cardName = cardNameBox.Text.Trim();
            decimal balance = 0;

            if (balanceBox.Text != "")
            {
                balance = Convert.ToDecimal(balanceBox.Text.Trim());
            }

            if (cardName != "" && balance != 0)
            {
                DepositLogic cardLogic = new DepositLogic();
                //cardLogic.CreateDeposit(cardName, balance, 1);
            }
        }

        private void CheckInput(string cardName, string balance)
        {
            if (cardName == "")
            { 
                cardNameBox.ToolTip = "Это поле не может быть пустым";
                cardNameBox.Background = Brushes.Red;
            }
            else
            {
                cardNameBox.ToolTip = "";
                cardNameBox.Background = Brushes.Transparent;
            }

            if (balance == "")
            {
                balanceBox.ToolTip = "Это поле не может быть пустым";
                balanceBox.Background = Brushes.Red;
            }
            else
            {
                balanceBox.ToolTip = "";
                balanceBox.Background = Brushes.Transparent;
            }
        }
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

    }
}
