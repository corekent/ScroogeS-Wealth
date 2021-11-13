﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Incomes
    {
        public decimal Amount { get; set; }
        public Card ToCard { get; set; }
        public Data Data { get; set; }
        public Data FixedData { get; set; }

    }
}