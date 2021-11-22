using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public abstract class Money<T> where T : IMoneyModel
    {
        public abstract Result<T> Create(string name, decimal amount, DateTime date, int fromId);
        public abstract Result<T> CreateConstExpense(string name, decimal amount, DateTime date, int fromId);
        public abstract Result<T> Remove(int id);
        public abstract Result<T> SetName(int id, string newName);
        public abstract Result<T> SetCategorie(int id, string newName);
        public abstract Result<T> SetAmount(int id, decimal newBalance);
    }
}
