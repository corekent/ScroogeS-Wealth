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
            int lastId;
            User user = new User(name);
            if (UserStorage.Users.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = UserStorage.Users.Last().Id + 1;
            }
            user.Id = lastId;
            UserStorage.Users.Add(user);
            WorkSpace workSpace = new WorkSpace(user);
            WorkSpaceStorage.workSpaces.Add(workSpace);
            return new Result<User>(1, user,"ok");
        }
    }
}
