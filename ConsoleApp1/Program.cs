using ScroogeS_Wealth.Business;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.IO;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2020, 06, 01);
            DateTime date2 = new DateTime(2021, 06, 01);
            


            //GenericStorage<Card> cardDate = new GenericStorage<Card>();
            //var acc = new Card("Kisa", 400);

            //Console.WriteLine(acc.GetType().Name);
            //cardDate.Update(acc, 0);
            //foreach (var cardt in cardDate.Get())
            //{
            //    Console.WriteLine($"Id : {cardt.Id}, Name: {cardt.Name}");
            //}

            //var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //Console.WriteLine(appDir);
            //string type = "Card";
            //var relativePath = $"C:\\Users\\{type}.json";
            //var fullPath = Path.Combine(appDir, relativePath);
            //Console.WriteLine(fullPath);

            //var baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //var appStorageFolder = Path.Combine(baseFolder, "ScroogeS-Wealth");
            //var fullPath2 = Path.Combine(appStorageFolder, relativePath);
            //Console.WriteLine(fullPath2);

            //Console.WriteLine(Environment.CurrentDirectory);
            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.ReadLine();

        }
    }
}
