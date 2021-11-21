using ScroogeS_Wealth.Business;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.ObjectModel;
using System.Windows;


namespace ScroogeS_Wealth.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<User> Names { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            GenericStorage<User> userStorage = new GenericStorage<User>();
            var names = userStorage.Get();
            Names = new ObservableCollection<User>(names);
            DataContext = Names;
        }

        private void Button_TransitionToCreateUserWindow_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.Show();
        }

        private void Button_TransitionToCreateCardWindow_Click(object sender, RoutedEventArgs e)
        {
            AddCardWindow addCardWindow = new AddCardWindow();
            addCardWindow.Show();
        }
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
