using ScroogeS_Wealth.Business;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            UserLogic userDate = new UserLogic();
            userDate.CreateUser("Юзер1");
 
            CashLogic cash = new CashLogic();
            cash.Create("Xuta", 333, 1);

            ExpenseLogic<Cash, Expense> expense = new ExpenseLogic<Cash, Expense>();
            expense.Create("narcota", 100, DateTime.Now, 1);

            Console.ReadLine();
        }
    }
}
