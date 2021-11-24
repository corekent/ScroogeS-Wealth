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
        public Deposit() { }

        public Deposit(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
