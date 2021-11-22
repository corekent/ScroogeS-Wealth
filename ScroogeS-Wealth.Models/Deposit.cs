using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Deposit : IBaseModel, IMoneyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<Income> Incomes { get; set; }
        public Deposit(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

    }
}
