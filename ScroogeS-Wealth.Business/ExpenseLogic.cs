using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class ExpenseLogic
    {
        public Result<Expense> Add(string name, decimal amount, int  cardId, DateTime time)
        {
            int lastId;

            Expense expense = new Expense(name, amount, time);

            if(ExpensesStorage.Expenses.Count == 0)
                lastId = 1;            
            else            
                lastId = ExpensesStorage.Expenses.Last().Id + 1;
            
            expense.Id = lastId;
            var card = CardStorage.Cards.FirstOrDefault(x => x.Id == cardId);

            if (card is null)
            {
                return new Result<Expense>(0, "Карта не найдена");
            }

            expense.Card = card;

            ExpensesStorage.Expenses.Add(expense);
            
            return new Result<Expense>(1, expense, "Расход учтён");

        }
        public void GetFromCard(Card fromCard)
        {
        }
        public void Set(decimal sum)
        {
        }
        public void Set(Card cardName)
        {
        }
        public void Set(DateTime time)
        {
        }
        public void DeleteLast()
        {
        }
    }
}
