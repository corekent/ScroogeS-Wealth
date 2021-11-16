using ScroogeS_Wealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Storage
{
    public static class ExpensesStorage
    {
        public static List<Expense> Expenses = new List<Expense>
        {
            new Expense {Id = 1, Name = "Test", Amount = 22, FromCard = CardStorage.Cards.FirstOrDefault(x => x.Id == 1)}       
        };
    }
}
