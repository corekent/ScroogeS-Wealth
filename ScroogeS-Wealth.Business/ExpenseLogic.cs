using Core;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class ExpenseLogic<T> where T : BaseModel
    {
        //public Result<Expense> Add(T body, string name, decimal amount, int id, DateTime time)
        //{
        //    GenericStorage<Expense> generalStore1 = new GenericStorage<Expense>();
        //    GenericStorage<T> generalStore = new GenericStorage<T>();
        //    var generals = generalStore.Get();
        //    Expense expense = new Expense(name, amount, time);
        //    int lastId = generals.Count;

        //    if (lastId == 0)
        //    {
        //        return new Result<Expense>(0, "Операция не выполнена!");
        //    }
        //    else
        //    {
        //        lastId += 1;
        //    }
        //    //cardStore.Get().Add(card);
        //    expense.Id = lastId;
        //    generals.Add(expense);

            

        //    if (body is null)
        //    {
        //        return new Result<Expense>(0, "Хранилище не найдено!");
        //    }

        //    if (body.Balance >= amount)
        //    {
        //        body.Balance -= amount;
        //        return new Result<Expense>(1, expense, "Расход учтён");
        //    }
        //    else
        //    {
        //        return new Result<Expense>(0, expense, "В хранилище не хватает средств!");
        //    }
        //}

        //public Result<Expense> Remove(int id, int userId)
        //{
        //    GenericStorage<T> generalStore = new GenericStorage<T>();

        //    Expense expense = ExpenseStorage.Expenses.Find(x => x.Id == id);
        //    Card card = CardStorage.Cards.FirstOrDefault(x => x.Id == id);

        //    if (ExpenseStorage.Expenses.Count == 0)
        //    {
        //        return new Result<Expense>(0, expense, "Расход не найден =(");
        //    }
        //    else
        //    {
        //        card.Balance += expense.Amount;
        //        ExpenseStorage.Expenses.Remove(expense);
        //        CardStorage.Cards.Remove(card);
        //        return new Result<Expense>(1, expense, "Расход удалён!");
        //    }
        //}

        //public Result<Expense> SetCategory(int id, string newName)
        //{
        //    Expense expense = ExpenseStorage.Expenses.Find(x => x.Id == id);

        //    if (expense is null)
        //    {
        //        return new Result<Expense>(0, expense, "Расход не найден!");
        //    }
        //    else
        //    {
        //        expense.Name = newName;
        //        return new Result<Expense>(1, expense, "Категория успешно изменена!");
        //    }
        //}
        //public Result<Expense> SetDate(int id, DateTime newDate)
        //{
        //    Expense expense = ExpenseStorage.Expenses.Find(x => x.Id == id);

        //    if (expense is null)
        //    {
        //        return new Result<Expense>(0, expense, "Расход не найден!");
        //    }
        //    else
        //    {
        //        expense.Date = newDate;
        //        return new Result<Expense>(1, expense, "Дата успешно изменена!");
        //    }
        //}
        //public Result<Expense> SetFrom(int id, int newId)
        //{
        //    Expense expense = ExpenseStorage.Expenses.Find(x => x.Id == id);

        //    if (expense is null)
        //    {
        //        return new Result<Expense>(0, expense, "Расход не найден!");
        //    }
        //    else
        //    {
        //        expense.Id = newId;
        //        return new Result<Expense>(1, expense, "Дата успешно изменена!");
        //    }
    }
}  