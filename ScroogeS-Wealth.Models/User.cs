using Core;
using System.Collections.Generic;

namespace ScroogeS_Wealth.Models
{
    public class User : IBaseModel
    {     
        public int Id { get; set; }
        public string Name { get; set; }
        public int workSpaceId { get; set; }


        public User(string name)
        {
            Name = name; 

        }
    }
}
