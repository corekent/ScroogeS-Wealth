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

        public List<Expense> Expense { get; set; }

        public List<Incomes> Incomes {get;set;}
    }
}
