using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class CashLogic
    {
        public Result<Cash> CreateCash(string name, decimal balance, int userId)
        {
            int lastId;
            Cash cash = new Cash(name, balance);
            if(CashStorage.Cash.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = CashStorage.Cash.Last().Id + 1;
            }
            cash.Id = lastId;
            CashStorage.Cash.Add(cash);
            var workSpace = WorkSpaceStorage.workSpaces.FirstOrDefault(x => x.GeneralUser.Id == userId);

            if (workSpace is null)
            {
                return new Result<Cash>(0, "Рабочее пространство не найдено");
            }
            workSpace.Cash.Add(cash);
            return new Result<Cash>(1, cash, "Копилка успешно добавлена");
        }
        public Result<Cash> RemoveCash(int id)
        {
            var cash = CashStorage.Cash.FirstOrDefault(x => x.Id == id);
            if (cash == null)
            {
                return new Result<Cash>(0, "Копилка не найдена");
            }
            CashStorage.Cash.Remove(cash);

            return new Result<Cash>(1, "Копилка удалена");
        }
        public Result<Cash> ChangeBalance(int id, decimal newbalance)
        //возвращать что? может, decimal?
        {
            var cash = CashStorage.Cash.FirstOrDefault(x => x.Id == id);
            if (cash == null)
            {
                return new Result<Cash>(0, "Копилка не найдена");
            }
            cash.Balance = newbalance;
            CashStorage.Cash.Find(x => x.Id == id).Balance = newbalance;

            return new Result<Cash>(1, cash, "Количество монеток в копилке изменилось");
        }
    }
}
