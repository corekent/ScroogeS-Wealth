using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class CashLogic : TypeMoneyStorage<Cash>
    {
        GenericStorage<Cash> elementStore = new GenericStorage<Cash>();
        public override Result<Cash> Create(string name, decimal balance, int id)
        {
            var elements = elementStore.Get();
            Cash element = new Cash(name, balance);
            int Id = CreateId(elements);
            element.Id = Id;
            elementStore.Add(element);
            return new Result<Cash>(1, element, "Карта добавлена");
        }
        public override Result<Cash> Remove(int id)
        {
            var element = FindId(id);
            elementStore.Get().Remove(element);
            return new Result<Cash>(1, element, " удалено");
        }
        public override Result<Cash> SetName(int id, string newName)
        {
            var element = FindId(id);
            element.Name = newName;
            return new Result<Cash>(1, element, "название изменено");
        }
        public override Result<Cash> SetBalance(int id, decimal newBalance)
        {
            var element = FindId(id);
            element.Balance = newBalance;
            return new Result<Cash>(1, element, "баланс изменен");
        }
        public override decimal GetBalance(int id)
        {
            var element = FindId(id);
            return element.Balance;
        }
        public override void BindWorkSpace(int elementId, int workSpaceId)
        {
            GenericStorage<WorkSpace> workSpaces = new GenericStorage<WorkSpace>();
            var workSpace = workSpaces.Get().FirstOrDefault(x => x.Id == workSpaceId);
            var element = FindId(elementId);
            workSpace.Cash.Add(element);
        }
        private Cash FindId(int id)
        {
            var elements = elementStore.Get();
            var element = elements.FirstOrDefault(x => x.Id == id);
            if (element is null)
            {
                return null;
            }
            return element;
        }
        private int CreateId(List<Cash> elements)
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

