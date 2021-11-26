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
            GenericStorage<WorkSpace> workSpaces = new GenericStorage<WorkSpace>();
            var worksps = workSpaces.Get();
            var workSpace = worksps.FirstOrDefault(x => x.Id == workSpaceId);
            var element = FindId(cardId);
            workSpace.Credits.Add(element);
        }
        public Credit FindId(int id)
        {
            var elements = elementStore.Get();
            var element = elements.FirstOrDefault(x => x.Id == id);
            if (element is null)
            {
                return null;
            }
            return element;
        }
        private int CreateId(List<Credit> elements)
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
        
        {
            double percentMonth = percentYears / 12;
            int creditTerm = CalcMonthCount(dateStart, dateEnd);
            decimal monthAmount = Convert.ToDecimal((allSum * percentMonth) / (1 - (1 + percentMonth) * (1 - creditTerm)));
            return monthAmount;
        }
        private int CalcMonthCount(DateTime dateStart, DateTime dateEnd)
        {
            dateEnd.Subtract(dateStart);
            TimeSpan diff = dateEnd - dateStart;
            int days = diff.Days;
            return days;
        }
        public decimal GetMonthlyPayment(decimal allSum, DateTime dateEnd)
        {
            int month = CalcMonthCount(DateTime.Now, dateEnd);
            decimal monthAmount = allSum / month;
            return monthAmount;
        }
    }
}
