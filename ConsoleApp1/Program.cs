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
            userDate.CreateUser("микроЮзер2");
            Console.WriteLine(userDate);
            CardLogic card = new CardLogic();
            card.Create("Xuta", 333, 1);
            Console.WriteLine(card);
            ExpenseLogic<Card, Expense> expenseLogic = new ExpenseLogic<Card, Expense>();
            expenseLogic.Create("СадаДажеНеДойдет", 100, DateTime.Now, 1);
            Console.WriteLine(expenseLogic);
            Console.ReadLine();
        }
    }
}
