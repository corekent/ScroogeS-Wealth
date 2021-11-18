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
        public Result<Account> CreateAccount(string name, decimal balance, int userId)
        {
            int lastId;

            Account account = new Account(name, balance);

            if (AccountStorage.Account.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = AccountStorage.Account.Last().Id + 1;
            }
            account.Id = lastId;

            AccountStorage.Account.Add(account);

            var workSpace = WorkSpaceStorage.workSpaces.FirstOrDefault(x => x.GeneralUser.Id == userId);

            if (workSpace is null)
            {
                return new Result<Account>(0, "Рабочее пространство не найдено");
            }

            workSpace.Accounts.Add(account);

            return new Result<Account>(1, account, "Счет добавлен");
        }
        public Result<Account> RemoveAccount(int id)
        {
            var account = AccountStorage.Account.FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                return new Result<Account>(0, "Карта не найдена");
            }
            AccountStorage.Account.Remove(account);

            return new Result<Account>(1, "Карта удалена");
        }
        public Result<Account> ChangeBalance(int id, decimal newbalance)
        //возвращать что? может, decimal?
        {
            var account = AccountStorage.Account.FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                return new Result<Account>(0, "Карта не найдена");
            }
            account.Balance = newbalance;
            AccountStorage.Account.Find(x => x.Id == id).Balance = newbalance;

            return new Result<Account>(1, account, "Баланс счета изменен");
        }
    }
}
