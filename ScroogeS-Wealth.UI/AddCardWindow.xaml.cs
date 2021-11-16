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

        private void Button_Create_Card_Click(object sender, RoutedEventArgs e)
        {
            CheckInput(cardNameBox.Text);
            string cardName = cardNameBox.Text.Trim();
            CheckInput(balanceBox.Text);
            decimal balance = Convert.ToDecimal(balanceBox.Text.Trim());
            CardLogic cardLogic = new CardLogic();
            cardLogic.CreateCard(cardName, balance, CardStorage.Cards.Last().Id);
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void CheckInput(string stringToCheck)
        {
            if (stringToCheck is null)
            {
                balanceBox.ToolTip = "Это поле введено некорректно";
                balanceBox.Background = Brushes.Red;
            }
            else
            {
                cardNameBox.ToolTip = "";
                cardNameBox.Background = Brushes.Transparent;
                balanceBox.ToolTip = "";
                balanceBox.Background = Brushes.Transparent;
            }
        }
    }
}
