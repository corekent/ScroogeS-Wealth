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
        GenericStorage<Cash> _storage = new GenericStorage<Cash>();
        public override Result<Cash> Create(string name, decimal balance, int id)
        {
            var elements = _storage.Get();
            Cash element = new Cash(name, balance);
            int Id = CreateId(elements);
            element.Id = Id;
            _storage.Add(element);
            return new Result<Cash>(1, element, "ok");
        }
        public override Result<Cash> Remove(int id)
        {
            var element = FindById(id);
            _storage.Get().Remove(element);
            return new Result<Cash>(1, element, " удалено");
        }
        public override Result<Cash> SetName(int id, string newName)
        {
            var element = FindById(id);
            element.Name = newName;
            return new Result<Cash>(1, element, "название изменено");
        }
        public override Result<Cash> SetBalance(int id, decimal newBalance)
        {
            var element = FindById(id);
            element.Balance = newBalance;
            return new Result<Cash>(1, element, "баланс изменен");
        }
        public override decimal GetBalance(int id)
        {
            var element = FindById(id);
            return element.Balance;
        }
        public override void BindWorkSpace(int elementId, int workSpaceId)
        {
            GenericStorage<WorkSpace> workSpaces = new GenericStorage<WorkSpace>();
            var workSpace = workSpaces.Get().FirstOrDefault(x => x.Id == workSpaceId);
            var element = FindById(elementId);
            workSpace.Cash.Add(element);
        }
        private Cash FindById(int id)
        {
            var elements = _storage.Get();
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

