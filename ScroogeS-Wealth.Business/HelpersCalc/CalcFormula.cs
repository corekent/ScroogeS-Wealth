using ScroogeS_Wealth.Business.HelpersStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.HelpersCalc
{
    public static class CalcFormula
    {        
        public static decimal CalcAmount(int id, double procent, DateTime dateStart, DateTime dateEnd)
        {
            var deposit = new DepositStorage();
            decimal balance = deposit.GetBalance(id);
            decimal amountProcent = CalcAnountProcent(procent, dateStart, dateEnd);
            balance = balance + amountProcent;
            return balance;
        }
        public static decimal CalcAnountProcent(double procent, DateTime dateStart, DateTime dateEnd)
        {
            double everyDayProcent = procent / 365;
            int days = CalcDate.CountDays(dateStart, dateEnd);
            decimal amount = (decimal)everyDayProcent * days;
            return amount;
        }
    }
}
