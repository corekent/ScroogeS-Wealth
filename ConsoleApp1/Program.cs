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
            //var card = userDate.Get().FirstOrDefault(x => x.Id == 2);
            //Console.WriteLine(card.Expense);
            //foreach (var us in userDate.Get())
            //{
            //    Console.WriteLine($"Id : {us.Id}, NameExp: {us.Expense.Name}");
            //}
            //DepositLogic dep = new DepositLogic();
            //dep.CreateDeposit("aaaaa", 300, 1);
            //Console.WriteLine(acc.GetType().Name);
            //depositDate.Add(acc);
            //foreach (var cardt in depositDate.Get())
            //{
            //    Console.WriteLine($"Id : {cardt.Id}, Name: {cardt.Name}");
            //}

            Console.ReadLine();















            ////var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ////Console.WriteLine(appDir);
            ////var relativePath = @"Data\\Card.json";
            ////var fullPath = Path.Combine(appDir, relativePath);
            ////Console.WriteLine(fullPath);
            //var baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//
            //string type = "Card";
            //var appStorageFolder = Path.Combine(baseFolder, $"ScroogeS-Wealth\\App_Data\\{type}.json");
            //Console.WriteLine(appStorageFolder);
        }
    }
}
