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
    public class CardStorage : TypeMoneyStorage<Card>
    {
        GenericStorage<User> _userStorage = new GenericStorage<User>();
        GenericStorage<Card> _cardStorage = new GenericStorage<Card>();
        public override Result<Card> Create(string name, decimal balance, int userId)
        {
            var cards = _cardStorage.Get();
            Card card = new Card(name, balance);
            int cashId = _cardStorage.GetNextAvailableId(cards);
            card.Id = cashId;
            _cardStorage.Add(card);
            var users = _userStorage.Get();
            var user = users.FirstOrDefault(x => x.Id == userId);
            if (user is null)
            {
                return new Result<Card>(0, ServiceMessages.entityNotFound);
            }
            user.Cards.Add(card);
            user.Balance += balance;
            _userStorage.Update(user, user.Id);
            return new Result<Card>(1, card, ServiceMessages.Created);
        }

        public override Result<Card> SetName(int id, string newName)
        {
            var card = _cardStorage.FindById(id);
            card.Name = newName;
            return new Result<Card>(1, card, ServiceMessages.nameChanged);
        }
        public override Result<Card> SetBalance(int id, decimal newBalance)
        {
            var card = _cardStorage.FindById(id);
            card.Balance = newBalance;
            return new Result<Card>(1, card, ServiceMessages.balanceChanged);

        }
        public override decimal GetBalance(int id)
        {
            var card = _cardStorage.FindById(id);
            return card.Balance;
        }
    }
}
