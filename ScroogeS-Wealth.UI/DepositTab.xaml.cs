using ScroogeS_Wealth.Business.HelpersCalc;
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
    /// Interaction logic for DepositTab.xaml
    /// </summary>
    public partial class DepositTab : UserControl
    {
        private ObservableCollection<User> _users;
        private ObservableCollection<Deposit> _deposits;
        private MainWindow _mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;

        public DepositTab()
        {
            InitializeComponent();
            _users = _mainWindow.GetUserList();
            usersComboBox.ItemsSource = _users;
        }

        private void Button_AddDeposit_Click(object sender, RoutedEventArgs e)
        {
            GenericStorage<Deposit> deposits = new GenericStorage<Deposit>();
            _deposits = new ObservableCollection<Deposit>(deposits.Get());
            string depositName = depositNameBox.Text.Trim();
            CheckInputName(depositName);
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

            if (depositName != "" && CheckDepositsForSameName(depositName) == false
                && balance != 0 && percent != 0 && date != default && user != null)
            {
                DepositStorage deposit = new DepositStorage();
                deposit.Create(depositName, balance, userId);
                MessageBox.Show($"Вклад добавлен пользователю {user.Name}!=)");
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

        private void CheckInputName(string depositName)
        {
            if (CheckDepositsForSameName(depositName))
            {
                depositNameBox.ToolTip = "Это имя уже занято";
                depositNameBox.Background = Brushes.Red;
            }
            else if (depositName == "")
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

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
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
            int months = Convert.ToInt32(depositMonthsSlider.Value);
            decimal newBalance = Math.Round(CalcFormula.CalcBalance(balance, percent, date, months));
            sliderText.Text = $"Через {depositMonthsSlider.Value.ToString()} месяцев у вас будет {newBalance} рублей"; 
        }
    }
}
