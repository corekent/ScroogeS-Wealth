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
        public Decimal MonthAmount { get; set; }
        public Credit(string name, decimal balance, DateTime dateStart, DateTime dateEnd)
        {
            Name = name;
            Balance = balance;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Type = "Кредит";

        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Credit m = obj as Credit;
            if (m as Credit == null)
                return false;
            return m.Name == Name && m.Type == Type && m.Balance == Balance && m.DateEnd == DateEnd && m.DateStart == DateStart;
        }
    }
}
