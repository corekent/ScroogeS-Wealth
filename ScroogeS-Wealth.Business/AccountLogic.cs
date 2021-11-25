using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class AccountLogic : TypeMoneyStorage<Account>
    {
        GenericStorage<Account> _elementStore = new GenericStorage<Account>();
        public override Result<Account> Create(string name, decimal balance, int id)
        {
            var elements = _elementStore.Get();
            Account element = new Account(name, balance);
            int Id = _elementStore.GetNextAvailableId(elements);
            element.Id = Id;
            _elementStore.Add(element);
            return new Result<Account>(1, element, "Карта добавлена");
        }

        public override Result<Account> SetName(int id, string newName)
        {
            var element = _elementStore.FindById(id);
            element.Name = newName;
            return new Result<Account>(1, element, "название изменено");
        }
        public override Result<Account> SetBalance(int id, decimal newBalance)
        {
            var element = _elementStore.FindById(id);
            element.Balance = newBalance;
            return new Result<Account>(1, element, "баланс изменен");

        }
        public override decimal GetBalance(int id)
        {
            var element = _elementStore.FindById(id);
            return element.Balance;
        }
    }
}
