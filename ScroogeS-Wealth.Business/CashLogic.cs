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
        GenericStorage<Cash> cashStore = new GenericStorage<Cash>();
        public Result<Cash> CreateCash(string name, decimal balance, int userId)
        {
            int lastId;
            Cash cash = new Cash(name, balance);
            if (cashStore.Get().Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = cashStore.Get().Last().Id + 1;
            }
            cash.Id = lastId;
            cashStore.Add(cash);
            return new Result<Cash>(1, cash, "Копилка добавлена");
        }
        //public Varifi
        public decimal GetBalance(int id)
        {
            var cashes = cashStore.Get();
            var cash = cashes.FirstOrDefault(x => x.Id == id);
            decimal balance = cash.Balance;
            return balance;
        }
        public Result<Cash> RemoveCash(int id)
        {
            var cash = cashStore.Get().FirstOrDefault(x => x.Id == id);
            if (cash == null)
            {
                return new Result<Cash>(0, "Копилка не найдена");
            }
            cashStore.Get().Remove(cash);

            return new Result<Cash>(1, "Копилка удалена");
        }
        public Result<Cash> ChangeBalance(int id, decimal newbalance)
        //возвращать что? может, decimal?
        {
            var cash = cashStore.Get().FirstOrDefault(x => x.Id == id);
            if (cash == null)
            {
                return new Result<Cash>(0, "Копилка не найдена");
            }
            cash.Balance = newbalance;
            cashStore.Get().Find(x => x.Id == id).Balance = newbalance;

            return new Result<Cash>(1, cash, "Количество монеток в копилке изменилось");
        }
    }
}
