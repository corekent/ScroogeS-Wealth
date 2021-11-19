﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Expense : BaseModel, IBaseModel
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Expense()
        {
        }
        public Expense(string name, decimal amount, DateTime date)
        {
            Name = name;
            Amount = amount;
            Date = date;
        }

    }
}
