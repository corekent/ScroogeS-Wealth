using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class UserLogic
    {
        public Result<User> CreateUser(string name)
        {
            User user = new User(name);

            return new Result<User>(1, user, "ok");
        }
    }
}
