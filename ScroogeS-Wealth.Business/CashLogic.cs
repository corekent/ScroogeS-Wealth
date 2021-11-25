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
        GenericStorage<User> _userStorage = new GenericStorage<User>();

        public override Result<Cash> Create(string name, decimal balance, int userId)
        {
            var elements = _storage.Get();
            Cash element = new Cash(name, balance);
            int cashId = _storage.CreateId(elements);
            element.Id = cashId;
            _storage.Add(element);
            var users = _userStorage.Get();
            var user = users.FirstOrDefault(x => x.Id == userId);
            if (user is null)
            {
                return new Result<Cash>(0, "сущность не найдена");
            }
            user.Cash.Add(element);
            user.Balance += balance;
            _userStorage.Update(user, user.Id);            
            return new Result<Cash>(1, element, "создано");            
        }
        
        public override Result<Cash> SetName(int id, string newName)
        {
            var element = _storage.FindById(id);
            element.Name = newName;
            return new Result<Cash>(1, element, "название изменено");
        }
        
        public override Result<Cash> SetBalance(int id, decimal newBalance)
        {
            var element = _storage.FindById(id);
            element.Balance = newBalance;
            return new Result<Cash>(1, element, "баланс изменен");
        }
        
        public override decimal GetBalance(int id)
        {
            var element = _storage.FindById(id);
            return element.Balance;
        }

        public override void BindWorkSpace(int elementId, int workSpaceId)
        {
            GenericStorage<WorkSpace> workSpaces = new GenericStorage<WorkSpace>();
            var workSpace = workSpaces.Get().FirstOrDefault(x => x.Id == workSpaceId);
            var element = _storage.FindById(elementId);
            workSpace.Cash.Add(element);
        }
    }
}

