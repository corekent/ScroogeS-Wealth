using ScroogeS_Wealth.Business;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //GenericStorage<Card> cardDate = new GenericStorage<Card>();
            //var acc = new Card("Kisa", 400);
            
            //Console.WriteLine(acc.GetType().Name);
            //cardDate.Update(acc, 0);
            //foreach(var cardt in cardDate.Get())
            //{
            //    Console.WriteLine($"Id : {cardt.Id}, Name: {cardt.Name}");
            //}
            //Console.ReadLine();
            Subtract();
            Console.ReadLine();

           static void Subtract()
            {
                DateTime date1 = new DateTime(2021, 3, 28, 0, 0, 0);
                DateTime date2 = new DateTime(2021, 3, 20, 0, 0, 0);
                TimeSpan diff = date1 - date2;
                int days = diff.Days;
                Console.WriteLine(days);
            }
        }
        
    }
    
}
