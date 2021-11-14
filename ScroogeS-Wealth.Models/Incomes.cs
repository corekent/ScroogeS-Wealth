using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Incomes
    {
        public decimal Amount { get; set; }
        public Card ToCard { get; set; }
        public DateTime Date { get; set; }
        //public DateTime FixedData { get; set; }
        public Incomes(decimal amount, Card cardname, DateTime data)
        {
            Amount = amount;
            ToCard = cardname;
            Date = data;
        }
    }
}
