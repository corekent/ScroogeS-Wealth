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
    public class CashStorage : TypeMoneyStorage<Cash>
    {
        GenericStorage<Cash> _cashStorage = new GenericStorage<Cash>();
        GenericStorage<User> _userStorage = new GenericStorage<User>();

        public override Result<Cash> Create(string name, decimal balance, int userId)
        {
            var cash = _cashStorage.Get();
            Cash cashElement = new Cash(name, balance);
            int cardId = _cashStorage.GetNextAvailableId(cash);
            cashElement.Id = cardId;
            _cashStorage.Add(cashElement);
            var users = _userStorage.Get();
            var user = users.FirstOrDefault(x => x.Id == userId);
            if (user is null)
            {
                return new Result<Cash>(0, ServiceMessages.entityNotFound);
            }
            user.Cash.Add(cashElement);
            user.Balance += balance;
            _userStorage.Update(user, user.Id);
            return new Result<Cash>(1, cashElement, ServiceMessages.Created);
        }

        public override Result<Cash> SetName(int id, string newName)
        {
            var cashElement = _cashStorage.FindById(id);
            cashElement.Name = newName;
            return new Result<Cash>(1, cashElement, ServiceMessages.nameChanged);
        }

        public override Result<Cash> SetBalance(int id, decimal newBalance)
        {
            var cashElement = _cashStorage.FindById(id);
            cashElement.Balance = newBalance;
            return new Result<Cash>(1, cashElement, ServiceMessages.balanceChanged);
        }

        public override decimal GetBalance(int id)
        {
            var cashElement = _cashStorage.FindById(id);
            return cashElement.Balance;
        }

    }
}
