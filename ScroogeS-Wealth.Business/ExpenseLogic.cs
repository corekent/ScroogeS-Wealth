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
        GenericStorage<T> _elementStore = new GenericStorage<T>();
        GenericStorage<Expense> _expenseStore = new GenericStorage<Expense>();

        public  Result<V> Create(string name, decimal amount, DateTime date, int fromId)
        {
            var expenses = _expenseStore.Get();
            var elements = _elementStore.Get();
            var element = elements.FirstOrDefault(x => x.Id == fromId);
            if (element is null)
            {
                return new Result<V>(0, ServiceMessages.entityNotFound);
            }
            var expense = new Expense(name, amount, date);
            int lastId = _expenseStore.GetNextAvailableId(expenses);
            expense.Id = lastId;
            _expenseStore.Add(expense);
            element.Expenses.Add(expense);
            element.Balance -= amount;
            _elementStore.Update(element, element.Id);
            return new Result<V>(1, ServiceMessages.expenseAdded);
        }
        public  Result<V> CreateConstExpense(string name, decimal amount, DateTime date, int fromId, int interval)
        {
            var expense = Create(name, amount, date, fromId);
            date.AddMonths(interval);
            var expenseNext = Create(name, amount, date, fromId);
            return new Result<V>(1, ServiceMessages.takeIntoAccountNextMonth);
        }
        public Result<V> SetName(int id, string newName)
        {
            var element = _expenseStore.FindById(id);
            element.Name = newName;
            return new Result<V>(1, ServiceMessages.nameChanged);
        }
        public Result<V> SetCategorie(int id, string newName)
        {
            return new Result<V>(1, ServiceMessages.categoryChanged);
        }
        public Result<V> SetAmount(int id, decimal newBalance)
        {
            var element = _expenseStore.FindById(id);
            element.Amount = newBalance;
            return new Result<V>(1, ServiceMessages.summChanged);
        }

        public  Result<V> CreateConstExpense(string name, decimal amount, DateTime date, int fromId)
        {
            throw new NotImplementedException();
        }
    }
}
