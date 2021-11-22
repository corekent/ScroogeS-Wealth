﻿using ScroogeS_Wealth.Business;
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
    /// Interaction logic for AddCashWindow.xaml
    /// </summary>
    public partial class AddCashWindow : Window
    {
        public AddCashWindow()
        {
            InitializeComponent();
        }
       
        private void CheckInput(string cashName, string balance)
        {
            if (cashName == "")
            {
                cashNameBox.ToolTip = "Это поле не может быть пустым";
                cashNameBox.Background = Brushes.Red;
            }
            else
            {
                cashNameBox.ToolTip = "";
                cashNameBox.Background = Brushes.Transparent;
            }
            //не работает, надо что-то другое
            //try
            //{
            //    decimal b = Convert.ToDecimal(balance);
            //}
            //catch
            //{
            //    balanceBox.ToolTip = "Некорректный ввод: введите цифры";
            //    balanceBox.Background = Brushes.Red;
            //}
            var val = balance.Trim(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
            if (string.IsNullOrEmpty(val))
            {
                balanceBox.ToolTip = "Некорректный ввод: введите цифры";
                 balanceBox.Background = Brushes.Red;
            }
            if (balance == "")
            {
                balanceBox.ToolTip = "Это поле не может быть пустым";
                balanceBox.Background = Brushes.Red;
            }
            else
            {
                balanceBox.ToolTip = "";
                balanceBox.Background = Brushes.Transparent;
            }
        }

       

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Button_Click_CreateCash(object sender, RoutedEventArgs e)
        {
            CheckInput(cashNameBox.Text, balanceBox.Text);
            string cashName = cashNameBox.Text.Trim();
            decimal balance = 0;

            
            if (balanceBox.Text != "")
            {
                balance = Convert.ToDecimal(balanceBox.Text.Trim());
            }

            if (cashName != "" && balance != 0)
            {
                CashLogic cashLogic = new CashLogic();
                cashLogic.CreateCash(cashName, balance, 1); 
                MessageBox.Show("Копилка успешно добавлена! =)");
            }
        }     
       
    }
}