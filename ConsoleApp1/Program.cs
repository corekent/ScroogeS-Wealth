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
            //GenericStorage<Expense> depositDate = new GenericStorage<Expense>();
            //GenericStorage<Card> userDate = new GenericStorage<Card>();
            //ExpenseLogic<Card> expenseLogic = new ExpenseLogic<Card>();
            //expenseLogic.Add("PipiskaExpence", 100, DateTime.Now, 2);
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
