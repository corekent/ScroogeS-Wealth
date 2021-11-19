using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public interface IMoneyStora : IBaseModel
    {

        public Expense Expense { get; set; }

        public Incomes Incomes {get;set;}
    }
}
