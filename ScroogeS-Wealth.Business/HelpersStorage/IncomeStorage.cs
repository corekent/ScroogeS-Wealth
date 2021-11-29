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
    public class IncomeStorage<T, V> where T : AssetModel where V : IBaseModel
    {
        GenericStorage<T> _elementStorage = new GenericStorage<T>();
        GenericStorage<Income> _incomesStorage = new GenericStorage<Income>();

        public Result<V> Create(string name, decimal amount, DateTime date, int fromId)
        {
            var incomes = _incomesStorage.Get();
            var elements = _elementStorage.Get();
            var element = elements.FirstOrDefault(x => x.Id == fromId);
            if (element is null)
            {
                return new Result<V>(0, ServiceMessages.entityNotFound);
            }
            var income = new Income(name, amount, date);
            int lastId = _incomesStorage.GetNextAvailableId(incomes);
            income.Id = lastId;
            _incomesStorage.Add(income);
            element.Incomes.Add(income);
            element.Balance += amount;
            _elementStorage.Update(element, element.Id);
            return new Result<V>(1, ServiceMessages.incomeAdded);
        }

        public Result<V> SetName(int id, string newName)
        {
            var element = _incomesStorage.FindById(id);
            element.Name = newName;
            return new Result<V>(1, ServiceMessages.nameChanged);
        }

        public Result<V> SetAmount(int id, decimal newBalance)
        {
            var element = _incomesStorage.FindById(id);
            element.Amount = newBalance;
            return new Result<V>(1, ServiceMessages.summChanged);
        }
    }
}
