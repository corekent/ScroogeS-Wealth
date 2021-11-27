using ScroogeS_Wealth.Business.HelpersStorage;
using ScroogeS_Wealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.HelpersCalc
{
    public static class CalcDate 
    {        
        public static int CountDays(DateTime dateStart, DateTime dateEnd)
        {
            dateEnd.Subtract(dateStart);
            TimeSpan diff = dateEnd - dateStart;
            int days = diff.Days;
            return days;
        }
        public static int CalcMonthCount(DateTime dateStart, DateTime dateEnd)
        {
            var span = dateEnd - dateStart;
            int months = (int)Math.Ceiling(span.TotalDays / 30.4);
            return months;
        }
    }
}
