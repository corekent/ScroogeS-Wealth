using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Spences
    {
        public decimal Amount { get; set; }
        public Card FromCard { get; set; }
        public Data Data { get; set; }
        public Data FixData { get; set; }
    }
}
