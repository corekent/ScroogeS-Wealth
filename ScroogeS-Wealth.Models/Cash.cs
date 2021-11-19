using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Cash : BaseModel
    {
        public decimal Balance { get; set; }
        public Cash(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
