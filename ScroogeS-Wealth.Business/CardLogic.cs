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
        
    }
}
