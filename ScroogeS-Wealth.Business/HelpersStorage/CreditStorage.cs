using Core;
using ScroogeS_Wealth.Business.HelpersCalc;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.HelpersStorage
{
    public class CreditStorage

    {
        GenericStorage<Credit> _creditStorage = new GenericStorage<Credit>();
        GenericStorage<User> _userStorage = new GenericStorage<User>();

        public Result<Credit> Create(string name, decimal balance, int userId, DateTime dateStart, DateTime dateEnd, double percent, string typeCredit)
        {
            var credits = _creditStorage.Get();
            Credit credit = new Credit(name, balance, dateStart, dateEnd);
            int creditId = _creditStorage.GetNextAvailableId(credits);
            credit.Id = creditId;
            double sum = Convert.ToDouble(balance);
            decimal monthAmount = CalcFormula.СhooseTypeOfLoan(typeCredit, sum, percent, dateStart, dateEnd);
            credit.MonthAmount = monthAmount;
            _creditStorage.Add(credit);
            var users = _userStorage.Get();
            var user = users.FirstOrDefault(x => x.Id == userId);
            if (user is null)
            {
                return new Result<Credit>(0, ServiceMessages.entityNotFound);
            }
            user.Credits.Add(credit);
            _userStorage.Update(user, user.Id);
            return new Result<Credit>(1, credit, ServiceMessages.Created);
        }
        public Result<Credit> SetName(int id, string newName)
        {
            var credit = _creditStorage.FindById(id);
            credit.Name = newName;
            return new Result<Credit>(1, credit, ServiceMessages.nameChanged);
        }
 
    }
}
