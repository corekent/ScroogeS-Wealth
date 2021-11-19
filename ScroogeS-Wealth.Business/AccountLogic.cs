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
        //public Result<Account> CreateAccount(string name, decimal balance, int userId)
        //{
        //    int lastId;

        //    Account account = new Account(name, balance);

        //    if (AccountStorage.Account.Count == 0)
        //    {
        //        lastId = 1;
        //    }
        //    else
        //    {
        //        lastId = AccountStorage.Account.Last().Id + 1;
        //    }
        //    account.Id = lastId;

        //    AccountStorage.Account.Add(account);

        //    var workSpace = WorkSpaceStorage.workSpaces.FirstOrDefault(x => x.GeneralUser.Id == userId);

        //    if (workSpace is null)
        //    {
        //        return new Result<Account>(0, "Рабочее пространство не найдено");
        //    }

        //    workSpace.Accounts.Add(account);

        //    return new Result<Account>(1, account, "Карта добавлена");
        //}
    }
}
