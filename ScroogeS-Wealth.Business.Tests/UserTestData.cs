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
            Result<User> created = new Result<User>(1, user1, ServiceMessages.Created);
            Result<User> removed = new Result<User>(1, ServiceMessages.deletionCompleted);
            Result<User> removedNegative = new Result<User>(0, ServiceMessages.entityNotFound);
            return index switch
            {
                1 => created,
                2 => removed,
                3 => removedNegative,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
