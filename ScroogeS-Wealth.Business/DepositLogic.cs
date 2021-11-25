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
        GenericStorage<Deposit> elementStore = new GenericStorage<Deposit>();
        public override Result<Deposit> Create(string name, decimal balance, int id)
        {
            var elements = elementStore.Get();
            Deposit element = new Deposit(name, balance);
            int Id = CreateId(elements);
            element.Id = Id;
            elementStore.Add(element);
            return new Result<Deposit>(1, element, "Карта добавлена");
        }
        public override Result<Deposit> Remove(int id)
        {
            var element = FindId(id);
            elementStore.Get().Remove(element);
            return new Result<Deposit>(1, element, "Вклад был удален");
        }
        public override Result<Deposit> SetName(int id, string newName)
        {
            var element = FindId(id);
            element.Name = newName;
            return new Result<Deposit>(1, element, "название изменено");
        }
        public override Result<Deposit> SetBalance(int id, decimal newBalance)
        {
            var element = FindId(id);
            element.Balance = newBalance;
            return new Result<Deposit>(1, element, "баланс изменен");
        }
        public override decimal GetBalance(int id)
        {
            var element = FindId(id);
            return element.Balance;
        }
        public override void BindWorkSpace(int elementId, int workSpaceId)
        {
            GenericStorage<WorkSpace> workSpaces = new GenericStorage<WorkSpace>();
            var workSpace = workSpaces.Get().FirstOrDefault(x => x.Id == workSpaceId);
            var element = FindId(elementId);
            workSpace.Deposits.Add(element);
        }
        public decimal CalcAmountOfPercent(double percent, DateTime openDate, DateTime closeDate)
        {
            double everyDayPercent = percent / 365;
            closeDate.Subtract(openDate);
            TimeSpan diff = closeDate - openDate;
            int days = diff.Days;
            decimal amount = (decimal)everyDayPercent * days;
            return amount;
        }
        public decimal CalcAmountOfMoney(int id, double percent, DateTime openDate, DateTime closeDate)
        {
            decimal balance = GetBalance(id);
            decimal percentAmount = CalcAmountOfPercent(percent, openDate, closeDate);
            balance += percentAmount;
            return balance;
        }
        private Deposit FindId(int id)
        {
            var elements = elementStore.Get();
            var element = elements.FirstOrDefault(x => x.Id == id);
            if (element is null)
            {
                return null;
            }
            return element;
        }
        private int CreateId(List<Deposit> elements)
        {
            int lastId;
            if (elements.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = elements.Last().Id + 1;
            }
            return lastId;
        }
    }
}
