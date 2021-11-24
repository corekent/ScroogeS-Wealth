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
        public static List<Cash> GetListForTest(int index)
        {
            Cash temp = new Cash("Bugs", 111);
            Cash temp2 = new Cash("Матрас", 3450);
            List<Cash> list = new List<Cash> { temp, temp2 };
            Cash temp3 = new Cash("Подушка", 450);
            List<Cash> list2 = new List<Cash> { temp, temp2, temp3 };
            return index switch
            {
                0 => list,
                1 => list2,
                _ => throw new NotImplementedException(),
            };

        }
        public static Result<Cash> GetResultForTest(int index)
        {
            Cash temp3 = new Cash("Подушка", 450);
            Result<Cash> temp1 = new Result<Cash>(1, temp3, "ok");
            Result<Cash> temp2 = new Result<Cash>(1, temp3, " удалено");
            return index switch
            {
                0 => temp1,
                1 => temp2,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
