using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Card : BaseModel, IMoneyStora
    {
        public decimal Balance { get; set; }
        public Expense Expense { get; set; }
        public Incomes Incomes { get; set; }

        public Card(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

    }
}
