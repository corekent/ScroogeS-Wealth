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
            GenericStorage<Card> cardDate = new GenericStorage<Card>();
            var acc = new Card("Kisa", 400);
            
            Console.WriteLine(acc.GetType().Name);
            cardDate.Update(acc, 0);
            foreach(var cardt in cardDate.Get())
            {
                Console.WriteLine($"Id : {cardt.Id}, Name: {cardt.Name}");
            }
            Console.ReadLine();
        }
    }
}
