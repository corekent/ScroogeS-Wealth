﻿using Core;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.HelpersStorage
{
    public class DepositStorage : TypeMoneyStorage<Deposit>
    {
        GenericStorage<Deposit> _depositStorage = new GenericStorage<Deposit>();
        public override Result<Deposit> Create(string name, decimal balance, int userId)
        {
            var deposits = _depositStorage.Get();
            Deposit deposit = new Deposit(name, balance);
            int Id = _depositStorage.GetNextAvailableId(deposits);
            deposit.Id = Id;
            _depositStorage.Add(deposit);
            return new Result<Deposit>(1, deposit, ServiceMessages.Created);
        }

        public override Result<Deposit> SetName(int id, string newName)
        {
            var deposit = _depositStorage.FindById(id);
            deposit.Name = newName;
            return new Result<Deposit>(1, deposit, ServiceMessages.nameChanged);
        }

        public override Result<Deposit> SetBalance(int id, decimal newBalance)
        {
            var deposit = _depositStorage.FindById(id);
            deposit.Balance = newBalance;
            return new Result<Deposit>(1, deposit, ServiceMessages.balanceChanged);
        }
        public override decimal GetBalance(int id)
        {
            var deposit = _depositStorage.FindById(id);
            return deposit.Balance;
        }       
    }
}
