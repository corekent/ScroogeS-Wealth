using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Deposit : AssetModel, IBaseModel
    {
        public Deposit(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Deposit m = obj as Deposit;
            if (m as Deposit == null)
                return false;
            return m.Name == Name && m.Balance == Balance;
        }
    }
}
