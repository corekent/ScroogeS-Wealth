using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Cash : AssetModel, IBaseModel
    {
        public Cash(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Cash m = obj as Cash;
            if (m as Cash == null)
                return false;           
            return m.Name == Name && m.Balance == Balance;

        }      


    }
}
