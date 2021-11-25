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
    public class IncomeLogic<T, V> where T : AssetModel where V : IBaseModel
    {
        GenericStorage<T> _elementStore = new GenericStorage<T>();
        GenericStorage<Income> _incomesStore = new GenericStorage<Income>();

        public Result<V> Create(string name, decimal amount, DateTime date, int fromId)
        {
            var incomes = _incomesStore.Get();
            var elements = _elementStore.Get();
            var element = elements.FirstOrDefault(x => x.Id == fromId);
            if (element is null)
            {
                return new Result<V>(0, "сущность не найдена");
            }
            var income = new Income(name, amount, date);
            int lastId = _incomesStore.GetNextAvailableId(incomes);
            income.Id = lastId;
            _incomesStore.Add(income);
            element.Incomes.Add(income);
            element.Balance -= amount;
            _elementStore.Update(element, element.Id);
            return new Result<V>(1, "расход добавлен");
        }
        public Result<V> CreateConstExpense(string name, decimal amount, DateTime date, int fromId, int interval)
        {
            var income = Create(name, amount, date, fromId);
            date.AddMonths(interval);
            var expenseNext = Create(name, amount, date, fromId);
            return new Result<V>(1, "расход будет учтен в следующем месяце");
        }
        public Result<V> SetName(int id, string newName)
        {
            var element = _incomesStore.FindById(id);
            element.Name = newName;
            return new Result<V>(1, "название изменено");
        }
        public Result<V> SetCategorie(int id, string newName)
        {
            return new Result<V>(1, "категория изменена ");
        }
        public Result<V> SetAmount(int id, decimal newBalance)
        {
            var element = _incomesStore.FindById(id);
            element.Amount = newBalance;
            return new Result<V>(1, "сумма изменена");
        }

        public Result<V> CreateConstExpense(string name, decimal amount, DateTime date, int fromId)
        {
            throw new NotImplementedException();
        }
    }    
}

