using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Card
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int Id { get; set; }

        public Card() { }
        public Card(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
