using Core;
using ScroogeS_Wealth.Business.HelpersStorage;
using ScroogeS_Wealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.Tests
{
    public class CreditTestData
    {
        public static User GetUserForTests()
        {
            UserStorage user = new UserStorage();
            Result<User> temp = user.CreateUser("Mr.Nobody");
            User user1 = temp.Body;
            return user1;
        }
        public static Result<Credit> GetResultForTest(int index)
        {
            DateTime dateStart = GetDateForTest(0);
            DateTime dateEnd = GetDateForTest(1);
            Credit cash1 = new Credit("Ipoteka", 10000, dateStart, dateEnd);
            Credit cash2 = new Credit("Loan", 100000, dateStart, dateEnd);
            Credit cash3 = new Credit("InstallmentPayment", 10000, dateStart, dateEnd);
            Result<Credit> temp1 = new Result<Credit>(1, cash1, ServiceMessages.Created);
            Result<Credit> temp2 = new Result<Credit>(1, cash2, ServiceMessages.Created);
            Result<Credit> temp3 = new Result<Credit>(1, cash3, ServiceMessages.Created);
            Result<Credit> temp4 = new Result<Credit>(0, ServiceMessages.entityNotFound);
            return index switch
            {
                0 => temp1,
                1 => temp2,
                2 => temp3,
                3 => temp4,
                _ => throw new NotImplementedException(),
            };
        }
        public static DateTime GetDateForTest(int idx)
        {
            DateTime dateStart = new DateTime(2021, 11, 29);
            DateTime dateEnd = new DateTime(2031, 11, 29);
            return idx switch
            {
                0 => dateStart,
                1 => dateEnd,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
