using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using ScroogeS_Wealth.Business.HelpersStorage;
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
    /// Interaction logic for CreditTab.xaml
    /// </summary>
    public partial class CreditTab : UserControl
    {
        private ObservableCollection<User> _users;
        private ObservableCollection<Credit> _credits;
        private MainWindow _mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        public CreditTab()
        {
            InitializeComponent();
            _users = _mainWindow.GetUserList();
            usersComboBox.ItemsSource = _users;
        }
        private void Button_AddCredit_Click(object sender, RoutedEventArgs e)
        {
            GenericStorage<Credit> credits = new GenericStorage<Credit>();
            _credits = new ObservableCollection<Credit>(credits.Get());
            string creditName = creditNameBox.Text.Trim();
            CheckInputName(creditName);
            decimal balance = 0;

            if (CheckInputDecimal(creditBalanceBox))
            {
                balance = Convert.ToDecimal(creditBalanceBox.Text);
            }
            decimal percent = 0;

            //if (CheckInputDecimal(creditPercentBox))
            //{
            //    percent = Convert.ToDecimal(creditPercentBox.Text);
            //}
            DateTime dateStart = default;

            if (CheckInputDateTime(creditOpeningDatePicker))
            {
                dateStart = creditOpeningDatePicker.SelectedDate.Value.Date;
            }
            DateTime dateEnd = default;

            if (CheckInputDateTime(creditClosingDatePicker))
            {
                dateEnd = creditOpeningDatePicker.SelectedDate.Value.Date;
            }
            DateTime dateMonth = default;

            if (CheckInputDateTime(creditClosingDatePicker))
            {
                dateMonth = creditOpeningDatePicker.SelectedDate.Value.Date;
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

            if (creditName != "" && CheckCreditsForSameName(creditName) == false
                && balance != 0 && dateEnd != default && dateStart != default && user != null)
            {
                CreditStorage credit = new CreditStorage();
                credit.Create(creditName, balance, userId, dateStart, dateEnd);
                MessageBox.Show($"Кредит добавлен пользователю {user.Name}!=)");
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
        private void CheckInputName(string creditName)
        {
            if (CheckCreditsForSameName(creditName))
            {
                creditNameBox.ToolTip = "Это имя уже занято";
                creditNameBox.Background = Brushes.Red;
            }
            else if (creditName == "")
            {
                creditNameBox.ToolTip = "Это поле нельзя оставлять пустым";
                creditNameBox.Background = Brushes.Red;
            }
            else
            {
                creditNameBox.ToolTip = "";
                creditNameBox.Background = Brushes.White;
            }
        }
        private bool CheckCreditsForSameName(string creditName)
        {
            foreach (var credit in _credits)
            {
                if (creditName == credit.Name)
                {
                    return true;
                }
            }
            return false;
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
    }

    
    
}
