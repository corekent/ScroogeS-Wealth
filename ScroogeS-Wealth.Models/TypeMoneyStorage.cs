﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public abstract class TypeMoneyStorage<T> where T : Product
    {
        public abstract Result<T> Create(string name, decimal balance, int id);
        public abstract Result<T> Remove(int id);
        public abstract Result<T> SetName(int id, string newName);
        //public abstract Result<T> SetOfOwnership(int elementId, int newUserId);
        public abstract Result<T> SetBalance(int id, decimal newBalance);
        public abstract decimal GetBalance(int id);
        public abstract void BindWorkSpace(int cardId, int workSpaceId);
    }
}