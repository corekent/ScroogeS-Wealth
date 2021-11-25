using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public abstract class TypeMoneyStorage<T> where T : AssetModel
    {
        public abstract Result<T> Create(string name, decimal balance, int id);
        public abstract Result<T> SetName(int id, string newName);
        public abstract Result<T> SetBalance(int id, decimal newBalance);
        public abstract decimal GetBalance(int id);
    }
}
