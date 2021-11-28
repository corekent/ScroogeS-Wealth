using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Income :  IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Income(string name, decimal amount, DateTime date)
        {
            Name = name;
            Amount = amount;
            Date = date;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Income m = obj as Income;
            if (m as Income == null)
                return false;
            return m.Name == Name && m.Date == Date && m.Amount==Amount;

        }
    }
}
