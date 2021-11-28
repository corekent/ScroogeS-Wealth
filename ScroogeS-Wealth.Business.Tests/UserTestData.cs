using Core;
using ScroogeS_Wealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.Tests
{
    public class UserTestData
    {
        public static Result<User> GetResultForTest(int index)
        {
            User user1 = new User("Mika");
            Result<User> temp1 = new Result<User>(1, user1, ServiceMessages.Created);
            return index switch
            {
                1 => temp1,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
