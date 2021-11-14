using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Account
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }

        public Account(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
