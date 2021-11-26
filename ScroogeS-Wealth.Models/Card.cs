using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Card : AssetModel, IMoneyModel
    {
        public Expense Expense { get; set; }
        public Income Incomes { get; set; }

        public Card(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

    }
}
