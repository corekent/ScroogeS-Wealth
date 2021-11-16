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
    /// Interaction logic for AddIncomeWindow.xaml
    /// </summary>
    public partial class AddIncomeWindow : Window
    {
        public AddIncomeWindow()
        {
            InitializeComponent();
        }

        private void Button_AddIncome_Click(object sender, RoutedEventArgs e)
        {
            CheckInput(amountBox.Text, incomeNameBox.Text);
            string incomeName = incomeNameBox.Text.Trim();
            //DateTime dateTime = Convert.ToDateTime(dateTimeBox.Text());

            decimal amount = 0;

            if (amountBox.Text != "")
            {
                amount = Convert.ToDecimal(amountBox.Text.Trim());
            }

            if (incomeName != "" && amount != 0)
            {
                // Создание экземпляра класса дохода
                // Добавление дохода
            }
        }

        private void CheckInput(string cardName, string balance)
        {
            //if (cardName == "")
            //{
            //    cardNameBox.ToolTip = "Это поле не может быть пустым";
            //    cardNameBox.Background = Brushes.Red;
            //}
            //else
            //{
            //    cardNameBox.ToolTip = "";
            //    cardNameBox.Background = Brushes.Transparent;
            //}

            //if (balance == "")
            //{
            //    balanceBox.ToolTip = "Это поле не может быть пустым";
            //    balanceBox.Background = Brushes.Red;
            //}
            //else
            //{
            //    balanceBox.ToolTip = "";
            //    balanceBox.Background = Brushes.Transparent;
            //}
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

    }
}
