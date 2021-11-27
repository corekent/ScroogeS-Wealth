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
    }
}
