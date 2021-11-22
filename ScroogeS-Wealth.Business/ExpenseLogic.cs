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
    public class ExpenseLogic<T> : Money<T> where T : IBaseModel
    {
        GenericStorage<T> elementStore = new GenericStorage<T>();
        GenericStorage<Expense> expenseStore = new GenericStorage<Expense>();

        public override Result<T> Create(string name, decimal amount, DateTime date, int fromId)
        {
            var expenses = expenseStore.Get();
            var elements = elementStore.Get();
            var element = elements.FirstOrDefault(x => x.Id == fromId);
            if (element is null)
            {
                return new Result<T>(0, "сущность не найдена");
            }
            Expense expense = new Expense(name, amount, date);
            int lastId = CreateId(expenses);
            expense.Id = lastId;
            expenseStore.Add(expense);
            elementStore.Update(element, element.Id);
            return new Result<T>(1, "расход добавлен");
        }
        public abstract Result<T> CreateConstExpense(string name, decimal amount, DateTime date, int fromId)
        {

        }
        public override Result<T> Remove(int id)
        {
            var element = FindId(id);
            expenseStore.Get().Remove(element);
            return new Result<T>(1, "расход удален");
        }
        public override Result<T> SetName(int id, string newName)
        {
            var element = FindId(id);
            element.Name = newName;
            return new Result<T>(1, "название изменено");
        }
        public override Result<T> SetCategorie(int id, string newName)
        {
            return new Result<T>(1, "категория изменена ");

        }
        public override Result<T> SetAmount(int id, decimal newBalance)
        {
            var element = FindId(id);
            element.Amount = newBalance;
            return new Result<T>(1, "сумма изменена");
        }
        private Expense FindId(int id)
        {
            var elements = expenseStore.Get();
            var element = elements.FirstOrDefault(x => x.Id == id);
            if (element is null)
            {
                return null;
            }
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
    }
}
