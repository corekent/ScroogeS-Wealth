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
    public class DepositLogic
    {
        GenericStorage<Deposit> depositStore = new GenericStorage<Deposit>();
        GenericStorage<WorkSpace> workSpaceStore = new GenericStorage<WorkSpace>();

        public Result<Deposit> CreateDeposit(string name, decimal balance, int userId)
        {
            int lastId;
            var deposits = depositStore.Get();
            var workSpases = workSpaceStore.Get();
            Deposit deposit = new Deposit(name, balance);
            if (deposits.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = deposits.Last().Id + 1;
            }
            deposit.Id = lastId;
            depositStore.Add(deposit);
            var workSpace = workSpases.FirstOrDefault(x => x.GeneralUser.Id == userId);

            if (workSpace is null)
            {
                return new Result<Deposit>(0, "Рабочее пространство не найдено");
            }
            workSpace.Deposits.Add(deposit);
            return new Result<Deposit>(1, deposit, "Вклад добавлен");
        }
        public decimal CalcAnountProcent(double procent, DateTime dateStart, DateTime dateEnd )
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
        public decimal GetBalance(int id)
        {
            var deposits = depositStore.Get();
            var dep = deposits.FirstOrDefault(x => x.Id == id);
            decimal balance = dep.Balance;
            return balance;
        }
    }
}
