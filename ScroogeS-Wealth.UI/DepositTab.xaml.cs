using ScroogeS_Wealth.Business;
using ScroogeS_Wealth.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ScroogeS_Wealth.UI
{
    /// <summary>
    /// Interaction logic for DepositTab.xaml
    /// </summary>
    public partial class DepositTab : UserControl
    {
        private ObservableCollection<User> _users;
        private MainWindow _mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;

        public DepositTab()
        {
            InitializeComponent();
            _users = _mainWindow.GetUserList();
            usersComboBox.ItemsSource = _users;
        }

        private void Button_AddDeposit_Click(object sender, RoutedEventArgs e)
        {
            string depositName = depositNameBox.Text.Trim();
            decimal balance = Convert.ToDecimal(depositBalanceBox.Text);
            //User userId = (User)(usersComboBox.SelectedItem);

            if (depositName != "" /*&& CheckForSameName(depositName) == false*/)
            {
                DepositLogic deposit = new DepositLogic();
                deposit.Create(depositName, balance, 1);

            }
        }
    }
}
