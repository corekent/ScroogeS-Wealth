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
        //public Result<Expense> Add(string name, decimal amount, int cardId, DateTime time)
        //{
        //    int lastId;

        //    Expense expense = new Expense(name, amount, time);

        //    if (ExpenseStorage.Expenses.Count == 0)
        //        lastId = 1;
        //    else
        //        lastId = ExpenseStorage.Expenses.Last().Id + 1;

        //    expense.Id = lastId;
        //    var card = ExpenseStorage.Expenses.FirstOrDefault(x => x.Id == cardId);

        //    if (card is null)
        //    {
        //        return new Result<Expense>(0, "Карта не найдена");
        //    }

        //    expense.Card = card;

        //    ExpenseStorage.Expenses.Add(expense);
        //    if (card.Balance >= amount)
        //    {
        //        card.Balance -= amount;
        //        return new Result<Expense>(1, expense, "Расход учтён");
        //    }
        //    else
        //    {
        //        return new Result<Expense>(0, expense, "на карте меньше нуля");
        //    }


        //}
    }
}
