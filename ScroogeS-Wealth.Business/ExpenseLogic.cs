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
    public class ExpenseLogic<T> where T: IMoneyStora
    {
        GenericStorage<T> store = new GenericStorage<T>();
        GenericStorage<Expense> expenseStore = new GenericStorage<Expense>();

        public Result<Expense> Add(string name, decimal amount, DateTime time, int fromId)
        {
            var expenses = expenseStore.Get();

            var element = store.Get().FirstOrDefault(x => x.Id == fromId);
            
            Expense expense = new Expense(name, amount, time);

            int lastId = Varification(expenses);

            expense.Id = lastId;

            element.Expense = expense;

            expenseStore.Add(expense);
            store.Update(element, element.Id);
            
            return new Result<Expense>(1, "расход добавлен");
        }
        private int Varification(List<Expense> expenses)
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