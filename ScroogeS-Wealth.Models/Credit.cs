using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Credit : AssetModel
    { 
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Credit(string name, decimal balance, DateTime dateStart, DateTime dateEnd)
        {
            Name = name;
            Balance = balance;
            DateStart = dateStart;
            DateEnd = dateEnd;
        }
    }
}
