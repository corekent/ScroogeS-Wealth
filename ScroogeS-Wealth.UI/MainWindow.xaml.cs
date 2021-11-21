using ScroogeS_Wealth.Business;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<User> Names { get; set; }
        public ObservableCollection<Cash> Cashes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            GenericStorage<User> userStorage = new GenericStorage<User>();
            var names = userStorage.Get();
            Names = new ObservableCollection<User>(names);
            DataContext = Names;
            //GenericStorage<Cash> cashesStorage = new GenericStorage<Cash>();
            //var cashes = cashesStorage.Get();
            //Cashes = new ObservableCollection<Cash>(cashes);
            //DataContext = Cashes;
            //DataGridCashesInfo.ItemsSource = Cashes;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_TransitionToCreateCashWindow_Click(object sender, RoutedEventArgs e)
        {
            AddCashWindow addCashWindow = new AddCashWindow();
            addCashWindow.Show();           
        }
       
    }
}
