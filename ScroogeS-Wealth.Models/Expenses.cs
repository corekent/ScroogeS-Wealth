using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Expenses
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Card FromCard { get; set; }
        public Deposit FromDeposit { get; set; }
    }
}
