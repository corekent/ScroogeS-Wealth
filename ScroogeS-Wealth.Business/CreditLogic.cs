using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class CreditLogic
    {
        GenericStorage<Credit> _storage = new GenericStorage<Credit>();
        GenericStorage<User> _userStorage = new GenericStorage<User>();

        public Result<Credit> Create(string name, decimal balance, int userId, DateTime dateStart, DateTime dateEnd)
        {
            var elements = _storage.Get();
            Credit element = new Credit(name, balance, dateStart, dateEnd);
            int cardId = _storage.GetNextAvailableId(elements);
            element.Id = cardId;
            _storage.Add(element);
            var users = _userStorage.Get();
            var user = users.FirstOrDefault(x => x.Id == userId);
            if (user is null)
            {
                return new Result<Credit>(0, "сущность не найдена");
            }
            user.Credits.Add(element);
            user.Balance += balance;
            _userStorage.Update(user, user.Id);
            return new Result<Credit>(1, element, "ok");
        }
        public void СhooseTypeOfLoan()
        {
           
        }
        private void Mortgage()
        {

        }
        private int CalcMonth(DateTime dateStart, DateTime dateEnd)
        {

        }
    }
}
