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
    public class CardLogic : TypeMoneyStorage<Card>
    {
        GenericStorage<User> _userStorage = new GenericStorage<User>();
        GenericStorage<Card> _elementStore = new GenericStorage<Card>();
        public override Result<Card> Create(string name, decimal balance, int userId)
        {
            var elements = _elementStore.Get();
            Card element = new Card(name, balance);
            int cashId = _elementStore.GetNextAvailableId(elements);
            element.Id = cashId;
            _elementStore.Add(element);
            var users = _userStorage.Get();
            var user = users.FirstOrDefault(x => x.Id == userId);
            if (user is null)
            {
                return new Result<Card>(0, ServiceMessages.entityNotFound);
            }
            user.Cards.Add(element);
            user.Balance += balance;
            _userStorage.Update(user, user.Id);
            return new Result<Card>(1, element, ServiceMessages.Created);
        }

        public override Result<Card> SetName(int id, string newName)
        {
            var element = _elementStore.FindById(id);
            element.Name = newName;
            return new Result<Card>(1, element, ServiceMessages.nameChanged);
        }
        public override Result<Card> SetBalance(int id, decimal newBalance)
        {
            var element = _elementStore.FindById(id);
            element.Balance = newBalance;
            return new Result<Card>(1, element, ServiceMessages.balanceChanged);

        }
        public override decimal GetBalance(int id)
        {
            var element = _elementStore.FindById(id);
            return element.Balance;
        }

        private int GetNextAvailableId(List<Card> elements)
        {
            int lastId;
            if (elements.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = elements.Last().Id + 1;
            }
            return lastId;
        }
    }
}
