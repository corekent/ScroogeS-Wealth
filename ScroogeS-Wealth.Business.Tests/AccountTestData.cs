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
    public static class AccountTestData
    {
        public static User GetUserForTests()
        {
            UserStorage user = new UserStorage();
            Result<User> temp = user.CreateUser("Mr.Nobody");
            User user1 = temp.Body;
            return user1;
        }
        public static int GetUserId(User user)
        {
            int userId = user.Id;
            return userId;
        }
        public static Result<Account> GetResultForTest(int index)
        {
            Account account1 = new Account("My Precious", 20450);
            Account account2 = new Account("LovelyAccount", 400350);
            Account account3 = new Account("My Precious", 1450);
            Result<Account> temp1 = new Result<Account>(1, account1, ServiceMessages.Created);
            Result<Account> temp2 = new Result<Account>(1, account2, ServiceMessages.nameChanged);
            Result<Account> temp3 = new Result<Account>(1, account3, ServiceMessages.balanceChanged);
            Result<Account> temp4 = new Result<Account>(0, ServiceMessages.entityNotFound);
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
