using Core;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class DepositLogic : TypeMoneyStorage<Deposit>
    {
        GenericStorage<Deposit> _elementStore = new GenericStorage<Deposit>();
        public override Result<Deposit> Create(string name, decimal balance, int id)
        {
            var elements = _elementStore.Get();
            Deposit element = new Deposit(name, balance);
            int Id = _elementStore.GetNextAvailableId(elements);
            element.Id = Id;
            _elementStore.Add(element);
            return new Result<Deposit>(1, element, ServiceMessages.Created);
        }

        public override Result<Deposit> SetName(int id, string newName)
        {
            var element = _elementStore.FindById(id);
            element.Name = newName;
            return new Result<Deposit>(1, element, ServiceMessages.nameChanged);
        }

        public override Result<Deposit> SetBalance(int id, decimal newBalance)
        {
            var element = _elementStore.FindById(id);
            element.Balance = newBalance;
            return new Result<Deposit>(1, element, ServiceMessages.balanceChanged);
        }
        public override decimal GetBalance(int id)
        {
            var element = _elementStore.FindById(id);
            return element.Balance;
        }

        public decimal CalcAnountProcent(double procent, DateTime dateStart, DateTime dateEnd)
        {
            double everyDayProcent = procent / 365;
            dateEnd.Subtract(dateStart);
            TimeSpan diff = dateEnd - dateStart;
            int days = diff.Days;
            decimal amount = (decimal)everyDayProcent * days;
            return amount;
        }

        public decimal CalcAmount(int id, double procent, DateTime dateStart, DateTime dateEnd)
        {
            decimal balance = GetBalance(id);
            decimal amountProcent = CalcAnountProcent(procent, dateStart, dateEnd);
            balance = balance + amountProcent;
            return balance;
        }
    }
}
