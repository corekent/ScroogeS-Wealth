using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public interface IMoneyModel : IBaseModel
    {
        public List<Expense> Expenses { get; set; }

        public List<Income> Incomes {get;set;}
    }
}
