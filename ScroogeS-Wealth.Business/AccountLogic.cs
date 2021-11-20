using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class AccountLogic
    {
        GenericStorage<Account> accountStore = new GenericStorage<Account>();
        public Result<Account> CreateAccount(string name, decimal balance, int userId)
        {
            int lastId;
            Account account = new Account(name, balance);
            if (accountStore.Get().Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = accountStore.Get().Last().Id + 1;
            }
            account.Id = lastId;
            accountStore.Get().Add(account);
            return new Result<Account>(1, account, "Карта добавлена");
        }
        //public Varifi
        public decimal GetBalance(int id)
        {
            var accounts = accountStore.Get();
            var account = accounts.FirstOrDefault(x => x.Id == id);
            decimal balance = account.Balance;
            return balance;
        }
        public Result<Account> RemoveAccount(int id)
        {
            var account = accountStore.Get().FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                return new Result<Account>(0, "Карта не найдена");
            }
            accountStore.Get().Remove(account);

            return new Result<Account>(1, "Карта удалена");
        }
        public Result<Account> ChangeBalance(int id, decimal newbalance)
        //возвращать что? может, decimal?
        {
            var account = accountStore.Get().FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                return new Result<Account>(0, "Карта не найдена");
            }
            account.Balance = newbalance;
            accountStore.Get().Find(x => x.Id == id).Balance = newbalance;

            return new Result<Account>(1, account, "Баланс карты изменен");
        }
    }
}
