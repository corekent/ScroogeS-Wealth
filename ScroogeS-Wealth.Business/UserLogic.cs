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
        GenericStorage<User> userStore = new GenericStorage<User>();

        public Result<User> CreateUser(string name)
        {
            User user = new User(name);
            var users = userStore.Get();
            WorkSpaceLogic workSpaceLogic = new WorkSpaceLogic();
            var workSpace = workSpaceLogic.Create();
            int id = CreateId(users);
            user.Id = id;
            user.workSpaceId = workSpace.Id;
            userStore.Add(user);
            return new Result<User>(1, user, "ok");
        }
        public int CreateId(List<User> users)
        {
            int lastId;
            if (users.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = users.Last().Id + 1;
            }
            return lastId;
        }
    }
}
