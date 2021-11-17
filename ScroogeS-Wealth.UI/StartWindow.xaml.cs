using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Linq;
using System.Windows;


namespace ScroogeS_Wealth.UI
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public class StartWindowState
    {
        public string UserName { get; set; }
        public decimal CardBalance { get; set; } 
    }

    public partial class StartWindow : Window
    {
        private StartWindowState _state;
        public string UserName { get; set; }
        public StartWindow()
        {
            InitializeComponent();

            CardStorage cardStorage = new CardStorage();
            decimal balance = CardStorage.Cards.Last().Balance;
            _state = new StartWindowState { CardBalance = balance, UserName = "Борис" };
            DataContext = _state;
        }

        private void Button_TransitionToCreateUser_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Button_TransitionToCreateCard_Click(object sender, RoutedEventArgs e)
        {
            AddCardWindow addCardWindow = new AddCardWindow();
            addCardWindow.Show();
        }
        private void Button_TransitionToCreateExpense_Click(object sender, RoutedEventArgs e)
        {
            AddExpenseWindow addExpenseWindow = new AddExpenseWindow();
            addExpenseWindow.Show();
        }

        private void Button_TransitionToCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_TransitionToCreateDeposit_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_TransitionToCreateCash_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_TransitionToCreateIncome_Click(object sender, RoutedEventArgs e)
        {
            AddIncomeWindow addIncomeWindow = new AddIncomeWindow();
            addIncomeWindow.Show();
        }
    }
}
