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

        public static decimal CalcMortgageMonthAmout(double allSum, double percentYears, DateTime dateStart, DateTime dateEnd)
        {
            double percentMonth = percentYears / 12;
            int creditTerm = CalcDate.CalcMonthCount(dateStart, dateEnd);
            decimal monthAmount = Convert.ToDecimal((allSum * percentMonth) / (1 - (1 + percentMonth) * (1 - creditTerm)));
            return monthAmount;
        }

        public static decimal CalcLoanMonthAmount(double allSum, double percentYears, DateTime dateStart, DateTime dateEnd)
        {
            double percentMonth = percentYears / 12;
            decimal monthAmount;
            int countMonth = CalcDate.CalcMonthCount(dateStart, dateEnd);
            if (percentYears == 0)
            {
                monthAmount = Convert.ToDecimal(allSum / countMonth);
                return monthAmount;
            }
            else
            {
                monthAmount = Convert.ToDecimal(allSum * (percentMonth + ((percentMonth) / (Math.Pow((1 + percentMonth), countMonth) - 1))));
            }
            return monthAmount;
        }
    }
}
