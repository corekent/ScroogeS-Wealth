using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Cash
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int Id { get; set; }
        public Cash() { }
        public Cash(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
