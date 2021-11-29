using Core;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.HelpersStorage
{
    public class ExpenseStorage<T, V> where T : AssetModel where V : IBaseModel
    {
        GenericStorage<T> _elementStorage = new GenericStorage<T>();
        GenericStorage<Expense> _expenseStorage = new GenericStorage<Expense>();

        public Result<V> Create(string name, decimal amount, DateTime date, int fromId)
        {
            var expenses = _expenseStorage.Get();
            var elements = _elementStorage.Get();
            var element = elements.FirstOrDefault(x => x.Id == fromId);
            if (element is null)
            {
                return new Result<V>(0, ServiceMessages.entityNotFound);
            }
            var expense = new Expense(name, amount, date);
            int lastId = _expenseStorage.GetNextAvailableId(expenses);
            expense.Id = lastId;
            _expenseStorage.Add(expense);
            element.Expenses.Add(expense);
            element.Balance -= amount;
            _elementStorage.Update(element, element.Id);
            return new Result<V>(1, ServiceMessages.expenseAdded);
        }

        public Result<V> SetName(int id, string newName)
        {
            var element = _expenseStorage.FindById(id);
            element.Name = newName;
            return new Result<V>(1, ServiceMessages.nameChanged);
        }
        public Result<V> SetAmount(int id, decimal newBalance)
        {
            var element = _expenseStorage.FindById(id);
            element.Amount = newBalance;
            return new Result<V>(1, ServiceMessages.summChanged);
        }
    }
}
