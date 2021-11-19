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

            if (depositStore.Get().Count == 0)     
            {
                lastId = 1;
            }
            else
            {
                lastId = depositStore.Get().Last().Id + 1;
            }
            deposit.Id = lastId;

            depositStore.Get().Add(deposit);

            var workSpace = workSpaceStore.Get().FirstOrDefault(x => x.GeneralUser.Id == userId);

            if (workSpace is null)
            {
                return new Result<Deposit>(0, "Рабочее пространство не найдено");
            }

            workSpace.Deposits.Add(deposit);
            return new Result<Deposit>(1, deposit, "Вклад добавлен");
        }

        public Result<Deposit> DeliteDeposit(Deposit deposit)
        {
            int lastId = depositStore.Get().Last().Id;
            if (lastId == 0)
            {
                return new Result<Deposit>(0, "Нечего удалять");
            }

            depositStore.Get().RemoveAt(deposit.Id);    
            lastId = depositStore.Get().Last().Id - 1;
            return new Result<Deposit>(1, deposit, "Вклад удален");


            //реализовать возможность перевода денег на карту во время удаления
        }

        public decimal GetBalance(int id)
        {            
            var deposits = depositStore.Get();
            var deposit = deposits.FirstOrDefault(x => x.Id == id);
            decimal balance = deposit.Balance;
            return balance;
        }

        public int SubtructDays(double procent, DateTime start, DateTime end)
        {            
            TimeSpan Days = end - start;
            int allDays = Days.Days;
            return allDays;
        }

        public decimal CalcAnount(int id, double procent, DateTime start, DateTime end)
        {
            double dayProcent = procent / 365;
            decimal summProcent = SubtructDays(procent, start, end);
            decimal anount = (decimal)dayProcent * summProcent;
            return summProcent;
        }



    }
}
