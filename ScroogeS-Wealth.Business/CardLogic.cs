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
        GenericStorage<Card> elementStore = new GenericStorage<Card>();
        public override Result<Card> Create(string name, decimal balance, int id)
        {
            var elements = elementStore.Get();
            Card element = new Card(name, balance);
            int cardId = CreateId(elements);
            element.Id = cardId;
            elementStore.Add(element);
            BindWorkSpace(cardId, id);
            return new Result<Card>(1, element, "Карта добавлена");
        }
        public override Result<Card> Remove(int id)
        {
            var element = FindId(id);
            elementStore.Get().Remove(element);
            return new Result<Card>(1, element, " удалено");
        }
        public override Result<Card> SetName(int id, string newName)
        {
            var element = FindId(id);
            element.Name = newName;
            return new Result<Card>(1, element, "название изменено");
        }
        public override Result<Card> SetBalance(int id, decimal newBalance)
        {
            var element = FindId(id);
            element.Balance = newBalance;
            return new Result<Card>(1, element, "баланс изменен");

        }
        public override decimal GetBalance(int id)
        {
            var element = FindId(id);
            return element.Balance;
        }
        public override void BindWorkSpace(int cardId, int workSpaceId)
        {
            GenericStorage<WorkSpace> workSpaces = new GenericStorage<WorkSpace>();
            var worksps = workSpaces.Get();
            var workSpace = worksps.FirstOrDefault(x => x.Id == workSpaceId);
            var element = FindId(cardId);
            workSpace.Cards.Add(element);
        }
        private Card FindId(int id)
        {
            var elements = elementStore.Get();
            var element = elements.FirstOrDefault(x => x.Id == id);
            if (element is null)
            {
                return null;
            }
            return element;
        }
        private int CreateId(List<Card> elements)
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
