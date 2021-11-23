using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Card : BeginModel, IBaseModel
    {
        public Card() { }

        public Card(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
