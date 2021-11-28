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

        public static decimal CalcBalance(decimal balance, decimal percent, DateTime openingDate, int months)
        {
            var deposit = new DepositStorage();
            DateTime closingDate = openingDate.AddMonths(months);
            decimal amountOfPercent = CalcAmountOfPercent(percent, openingDate, closingDate);
            balance += balance * (amountOfPercent / 100);
            return balance;
        }

        public static decimal CalcAmountOfPercent(decimal percent, DateTime openingDate, DateTime closingDate)
        {
            decimal everyDayPercent = percent / 365;
            int days = CalcDate.CountDays(openingDate, closingDate);
            decimal amountOfPercent = (decimal)everyDayPercent * days;
            return amountOfPercent;
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
