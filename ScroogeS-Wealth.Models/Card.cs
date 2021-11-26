using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Card : AssetModel, IMoneyModel
    {
        public Expense Expense { get; set; }
        public Income Income { get; set; }

        public Card(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Card m = obj as Card;
            if (m as Card == null)
                return false;
            return m.Name == Name && m.Balance == Balance && m.Expense == Expense && m.Income == Income;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

    }
}
