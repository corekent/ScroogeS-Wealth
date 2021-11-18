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
        public Result<Card> CreateCard(string name, decimal balance, int userId)
        {
            int lastId;

            Card card = new Card(name, balance);

            if(CardStorage.Cards.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = CardStorage.Cards.Last().Id + 1;
            }
            card.Id = lastId;

            CardStorage.Cards.Add(card);

            var workSpace = WorkSpaceStorage.workSpaces.FirstOrDefault(x => x.GeneralUser.Id == userId);

            if (workSpace is null)
            {
                return new Result<Card>(0, "Рабочее пространство не найдено");
            }

            workSpace.Cards.Add(card);

            return new Result<Card>(1, card, "Карта добавлена");
        }
        public decimal GetBalance(int id)
        {
            var card = CardStorage.Cards.FirstOrDefault(x => x.Id == id);
            decimal balance = card.Balance;
            return balance;
        }
        public Result<Card> RemoveCard(int id)
        {
            var card = CardStorage.Cards.FirstOrDefault(x => x.Id == id);
            if (card == null)
            {
                return new Result<Card>(0, "Карта не найдена");
            }
            CardStorage.Cards.Remove(card);

            return new Result<Card>(1, "Карта удалена");
        }
        public Result<Card>  ChangeBalance(int id, decimal newbalance)
        //возвращать что? может, decimal?
        {
            var card = CardStorage.Cards.FirstOrDefault(x => x.Id == id);
            if (card == null)
            {
                return new Result<Card>(0, "Карта не найдена");
            }
            card.Balance = newbalance;
            CardStorage.Cards.Find(x => x.Id == id).Balance=newbalance;

            return new Result<Card>(1, card, "Баланс карты изменен");
        }
    }
}
