using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Account : AssetModel, IBaseModel
    {
        public Account() { }

        public Account(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Account m = obj as Account;
            if (m as Account == null)
                return false;
            return m.Name == Name && m.Balance == Balance;
        }
    }
}
