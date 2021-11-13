using ScroogeS_Wealth.Models;
using System;
using System.Collections.Generic;

namespace ScroogeS_Wealth.Storage
{
    public static class UserStorage
    {
        public static List<User> Users = new List<User>
        {
            new User{ Id = 1, Name = "Tom"},
            new User{ Id = 2, Name = "Bob"},
            new User{ Id = 3, Name = "Fil"}
        };
    }
}
