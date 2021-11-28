using Core;
using ScroogeS_Wealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.Tests
{
    class DepositTestData
    {
        public static Result<Deposit> GetResultForTest(int index)
        {
            Deposit deposit1 = new Deposit("Накопительный", 210000);
            Deposit deposit2 = new Deposit("На тачку", 210000);
            Deposit deposit3 = new Deposit("Накопительный", 85000);
            Result<Deposit> temp1 = new Result<Deposit>(1, deposit1, ServiceMessages.Created);
            Result<Deposit> temp2 = new Result<Deposit>(1, deposit2, ServiceMessages.nameChanged);
            Result<Deposit> temp3 = new Result<Deposit>(1, deposit3, ServiceMessages.balanceChanged);
            Result<Deposit> temp4 = new Result<Deposit>(0, ServiceMessages.entityNotFound);
            return index switch
            {
                0 => temp1,
                1 => temp2,
                2 => temp3,
                3 => temp4,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
