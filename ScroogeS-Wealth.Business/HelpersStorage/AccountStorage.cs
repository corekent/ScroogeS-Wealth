using Core;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.HelpersStorage
{
    public class AccountStorage : TypeMoneyStorage<Account>
    {
        GenericStorage<Account> _accountStorage = new GenericStorage<Account>();
        public override Result<Account> Create(string name, decimal balance, int id)
        {
            var accounts = _accountStorage.Get();
            Account account = new Account(name, balance);
            int Id = _accountStorage.GetNextAvailableId(accounts);
            account.Id = Id;
            _accountStorage.Add(account);
            return new Result<Account>(1, account, ServiceMessages.Created);
        }

        public override Result<Account> SetName(int id, string newName)
        {
            var account = _accountStorage.FindById(id);
            account.Name = newName;
            return new Result<Account>(1, account, ServiceMessages.nameChanged);
        }
        public override Result<Account> SetBalance(int id, decimal newBalance)
        {
            var account = _accountStorage.FindById(id);
            account.Balance = newBalance;
            return new Result<Account>(1, account, ServiceMessages.balanceChanged);

        }
        public override decimal GetBalance(int id)
        {
            var account = _accountStorage.FindById(id);
            return account.Balance;
        }
    }
}
