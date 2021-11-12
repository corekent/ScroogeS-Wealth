using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Incomes
    {
        public decimal AmountIncomes { get; set; }
        public Card IncomesToCard { get; set; }
        public Data IncomeData { get; set; }
        public Data FixedIncomeData { get; set; }
    }
}
