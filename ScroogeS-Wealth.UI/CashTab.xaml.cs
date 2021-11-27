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
    /// Interaction logic for CashTab.xaml
    /// </summary>
    public partial class CashTab : UserControl
    {
        private GenericStorage<Cash> _cashes;
        public CashTab()
        {
            InitializeComponent();
            //GenericStorage<Cash> cashes = new GenericStorage<Cash>();
            var cashes =_cashes.Get();
            //userComboBox.ItemsSource = MainWindow.Users;
            CashComboBox.ItemsSource = cashes.Name;
            DataGridCashInfo.ItemsSource = cashes;
        }
    }
}
