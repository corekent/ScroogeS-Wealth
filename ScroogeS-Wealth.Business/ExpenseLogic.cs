using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class ExpenseLogic<T>
    {
        public Result<Expense> Add(string name, decimal amount, int cardId, DateTime time)
        {
            int lastId;

            Expense expense = new Expense(name, amount, time);

            if (ExpenseStorage.Expenses.Count == 0)
                lastId = 1;
            else
                lastId = ExpenseStorage.Expenses.Last().Id + 1;

            expense.Id = lastId;
            var card = CardStorage.Cards.FirstOrDefault(x => x.Id == cardId);

            if (card is null)
            {
                return new Result<Expense>(0, "Карта не найдена");
            }

            expense.Card = card;

            ExpenseStorage.Expenses.Add(expense);
            if (card.Balance >= amount)
            {
                card.Balance -= amount;
                return new Result<Expense>(1, expense, "Расход учтён");
            }
            else
            {
                return new Result<Expense>(0, expense, "на карте меньше нуля");
            }
        }

        public Result<Expense> Remove(int id, int userId)
        {
            Expense expense = ExpenseStorage.Expenses.Find(x => x.Id == id);
            Card card = CardStorage.Cards.FirstOrDefault(x => x.Id == id);

            if (ExpenseStorage.Expenses.Count == 0)
            {
                return new Result<Expense>(0, expense, "Расход не найден =(");
            }
            else
            {
                card.Balance += expense.Amount;
                ExpenseStorage.Expenses.Remove(expense);
                CardStorage.Cards.Remove(card);
                return new Result<Expense>(1, expense, "Расход удалён!");
            }
        }

        public Result<Expense> SetCategory(int id, string newName)
        {
            Expense expense = ExpenseStorage.Expenses.Find(x => x.Id == id);

            if (expense is null)
            {
                return new Result<Expense>(0, expense, "Расход не найден!");
            }
            else
            {
                expense.Name = newName;
                return new Result<Expense>(1, expense, "Категория успешно изменена!");
            }
        }
        public Result<Expense> SetDate(int id, DateTime newDate)
        {
            Expense expense = ExpenseStorage.Expenses.Find(x => x.Id == id);

            if (expense is null)
            {
                return new Result<Expense>(0, expense, "Расход не найден!");
            }
            else
            {
                expense.Date = newDate;
                return new Result<Expense>(1, expense, "Дата успешно изменена!");
            }
        }
        public Result<Expense> SetFrom(int id, int newId)
        {
            Expense expense = ExpenseStorage.Expenses.Find(x => x.Id == id);

            if (expense is null)
            {
                return new Result<Expense>(0, expense, "Расход не найден!");
            }
            else
            {
                expense.Id = newId;
                return new Result<Expense>(1, expense, "Дата успешно изменена!");
            }
        }
        //private Result<Expense> AddTo(T body, Expense expense, decimal amount, int id)
        //{
        //    var operand = body.Cards.FirstOrDefault(x => x.Id == id);

        //    if (operand is null)
        //    {
        //        return new Result<Expense>(0, "Карта не найдена");
        //    }

        //    //expense.Card = card;

        //    ExpenseStorage.Expenses.Add(expense);
        //    if (operand.Balance >= amount)
        //    {
        //        operand.Balance -= amount;
        //        return new Result<Expense>(1, expense, "Расход учтён!");
        //    }
        //    else
        //    {
        //        return new Result<Expense>(0, expense, "В хранилище нет столько денег!");
        //    }
        //}
    }
}
