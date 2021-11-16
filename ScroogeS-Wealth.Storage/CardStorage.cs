using ScroogeS_Wealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Storage
{
    public class CardStorage
    {
        public static List<Card> Cards = new List<Card>
        {
            new Card{Id = 1, Name = "AlfaBank", Balance = 0, }, 
        };
    }
}
