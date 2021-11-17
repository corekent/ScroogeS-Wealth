using ScroogeS_Wealth.Business;
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
            //CheckInput(amountBox.Text, incomeNameBox.Text);
            string incomeName = incomeNameBox.Text.Trim();
            DateTime dateTime = DateTime.Parse(dateTimeBox.Text.Trim());

            decimal amount = 0;

            if (amountBox.Text != "")
            {
                amount = Convert.ToDecimal(amountBox.Text.Trim());
            }

            if (incomeName != "" && amount != 0)
            {
                IncomeLogic expenseLogic = new IncomeLogic();
                expenseLogic.Add(incomeName, amount, 1, dateTime);
                MessageBox.Show("Доход добавлен!");
            }
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
