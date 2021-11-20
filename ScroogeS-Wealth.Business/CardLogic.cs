using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class CardLogic
    {
        GenericStorage<Card> cardStore = new GenericStorage<Card>();
        public Result<Card> CreateCard(string name, decimal balance, int userId)
        {
            int lastId;
            Card card = new Card(name, balance);
            if(cardStore.Get().Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = cardStore.Get().Last().Id + 1;
            }
            card.Id = lastId;
            cardStore.Get().Add(card);
            return new Result<Card>(1, card, "Карта добавлена");
        }
        //public Varifi
        public decimal GetBalance(int id)
        {
            var cards = cardStore.Get();
            var card = cards.FirstOrDefault(x => x.Id == id);
            decimal balance = card.Balance;
            return balance;
        }
        public Result<Card> RemoveCard(int id)
        {        
            var card = cardStore.Get().FirstOrDefault(x => x.Id == id);
            if (card == null)
            {
                return new Result<Card>(0, "Карта не найдена");
            }
            cardStore.Get().Remove(card);

            return new Result<Card>(1, "Карта удалена");
        }
        public Result<Card> ChangeBalance(int id, decimal newbalance)
        //возвращать что? может, decimal?
        {
            var card = cardStore.Get().FirstOrDefault(x => x.Id == id);
            if (card == null)
            {
                return new Result<Card>(0, "Карта не найдена");
            }
            card.Balance = newbalance;
            cardStore.Get().Find(x => x.Id == id).Balance = newbalance;

            return new Result<Card>(1, card, "Баланс карты изменен");
        }


    
}
