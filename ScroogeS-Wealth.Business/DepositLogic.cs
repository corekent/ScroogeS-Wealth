using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class DepositLogic
    {
        public Result<Deposit> CreateDeposit(string name, decimal balance, int userId)
        {
            int lastId;

            Deposit deposit = new Deposit(name, balance);

            if (DepositStorage.Deposites.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = DepositStorage.Deposites.Last().Id + 1;
            }
            deposit.Id = lastId;

            DepositStorage.Deposites.Add(deposit);

            var workSpace = WorkSpaceStorage.workSpaces.FirstOrDefault(x => x.GeneralUser.Id == userId);

            if (workSpace is null)
            {
                return new Result<Deposit>(0, "Рабочее пространство не найдено");
            }

            workSpace.Deposits.Add(deposit);

            return new Result<Deposit>(1, deposit, "Вклад добавлен");            
        }
    }
}
