using Core;
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
        private GenericStorage<User> _userStore = new GenericStorage<User>();

        public Result<User> CreateUser(string name)
        {
            User user = new User(name);
            var users = _userStore.Get();
            int id = _userStore.GetNextAvailableId(users);
            user.Id = id;
            _userStore.Add(user);
            return new Result<User>(1, user, ServiceMessages.Created);
        }
    }
}
