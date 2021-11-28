﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Account : AssetModel, IBaseModel
    {
        public Account(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
