using ScroogeS_Wealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.Tests
{
    public class CashTestData
    {
       
        public static Result<Cash> GetResultForTest(int index)
        {
            Cash cash1 = new Cash("Подушка", 450);
            Cash cash2 = new Cash("Под подушкой", 450);
            Cash cash3 = new Cash("Подушка", 1450);
            Result<Cash> temp1 = new Result<Cash>(1, cash1, "создано");
            Result<Cash> temp2 = new Result<Cash>(1, cash2, "название изменено");
            Result<Cash> temp3 = new Result<Cash>(1, cash3, "баланс изменен");
            Result<Cash> temp4 = new Result<Cash>(0, "сущность не найдена");
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
