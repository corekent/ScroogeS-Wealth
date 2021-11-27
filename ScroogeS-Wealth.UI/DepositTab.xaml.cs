using ScroogeS_Wealth.Business;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ScroogeS_Wealth.UI
{
    /// <summary>
    /// Interaction logic for DepositTab.xaml
    /// </summary>
    public partial class DepositTab : UserControl
    {
        private ObservableCollection<User> _users;
        private List<Deposit> _deposits;
        private MainWindow _mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        public decimal MoneyAmountWithPercent { get; set; }

        public DepositTab()
        {
            InitializeComponent();
            _users = _mainWindow.GetUserList();
            usersComboBox.ItemsSource = _users;

        }

        private void Button_AddDeposit_Click(object sender, RoutedEventArgs e)
        {
            GenericStorage<Deposit> deposits = new GenericStorage<Deposit>();
            _deposits = new List<Deposit>(deposits.Get());
            string depositName = depositNameBox.Text.Trim();
            decimal balance = 0;

            if (CheckInputDecimal(depositBalanceBox))
            {
                balance = Convert.ToDecimal(depositBalanceBox.Text);
            }
            decimal percent = 0;

            if (CheckInputDecimal(depositPercentBox))
            {
                percent = Convert.ToDecimal(depositPercentBox.Text);
            }
            DateTime date = default;

            if (CheckInputDateTime(depositOpeningDatePicker))
            {
                date = depositOpeningDatePicker.SelectedDate.Value.Date;
            }
            CheckInputData(depositName, balance, percent);
            User userId = (User)(usersComboBox.SelectedItem);

            if (depositName != "" && CheckDepositsForSameName(depositName) == false
                && balance != 0 && percent != 0 && date != default)
            {
                DepositLogic deposit = new DepositLogic();
                deposit.Create(depositName, balance, 1);
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

        private bool CheckInputDateTime(DatePicker input)
        {
            if (DateTime.TryParse(input.Text, out _))
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

        private void CheckInputData(string depositName, decimal balance, decimal percent)
        {
            if (CheckDepositsForSameName(depositName))
            {
                depositNameBox.ToolTip = "Это имя уже занято";
                depositNameBox.Background = Brushes.Red;
            }
            else if (depositName == "" || balance == 0 || percent == 0)
            {
                depositNameBox.ToolTip = "Это поле нельзя оставлять пустым";
                depositNameBox.Background = Brushes.Red;

            }
            else
            {
                depositNameBox.ToolTip = "";
                depositNameBox.Background = Brushes.White;
            }
        }

        private bool CheckDepositsForSameName(string depositName)
        {
            foreach (var deposit in _deposits)
            {
                if (depositName == deposit.Name)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
