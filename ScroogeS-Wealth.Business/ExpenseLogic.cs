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
    public class ExpenseLogic<T, V> where T : AssetModel where V : IBaseModel
    {
        GenericStorage<T> elementStore = new GenericStorage<T>();
        GenericStorage<Expense> expenseStore = new GenericStorage<Expense>();

        public  Result<V> Create(string name, decimal amount, DateTime date, int fromId)
        {
            var expenses = expenseStore.Get();
            var elements = elementStore.Get();
            var element = elements.FirstOrDefault(x => x.Id == fromId);
            if (element is null)
            {
                return new Result<V>(0, "сущность не найдена");
            }
            var expense = new Expense(name, amount, date);
            int lastId = CreateId(expenses);
            expense.Id = lastId;
            expenseStore.Add(expense);
            element.Expenses.Add(expense);
            element.Balance -= amount;
            elementStore.Update(element, element.Id);
            return new Result<V>(1, "расход добавлен");
        }
        public  Result<V> CreateConstExpense(string name, decimal amount, DateTime date, int fromId, int interval)
        {
            var expense = Create(name, amount, date, fromId);
            date.AddMonths(interval);
            var expenseNext = Create(name, amount, date, fromId);
            return new Result<V>(1, "расход будет учтен в следующем месяце");
        }
        public  Result<V> Remove(int id)
        {
            var element = FindId(id);
            expenseStore.Get().Remove(element);
            return new Result<V>(1, "расход удален");
        }
        public Result<V> SetName(int id, string newName)
        {
            var element = FindId(id);
            element.Name = newName;
            return new Result<V>(1, "название изменено");
        }
        public Result<V> SetCategorie(int id, string newName)
        {
            return new Result<V>(1, "категория изменена ");
        }
        //public Result<V> SetAmount(int id, decimal newBalance)
        //{
        //    var element = FindId(id);
        //    element.Balance = newBalance;
        //    return new Result<V>(1, "сумма изменена");
        //}
        private Expense FindId(int id)
        {
            var elements = expenseStore.Get();
            var element = elements.FirstOrDefault(x => x.Id == id);
            return element;
        }
        private int CreateId(List<Expense> expenses)
        {
            int lastId;
            if (expenses.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = expenses.Last().Id + 1;
            }
            return lastId;
        }
        private Result<T> FuckingCheck(T element, int id)
        {
            element = elementStore.Get().FirstOrDefault(x => x.Id == id);
            return new Result<T>(1, element, "");
        }

        public  Result<V> CreateConstExpense(string name, decimal amount, DateTime date, int fromId)
        {
            throw new NotImplementedException();
        }
    }
}
