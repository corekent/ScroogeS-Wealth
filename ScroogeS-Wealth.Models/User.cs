using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class User : IBaseModel
    {     
        public int Id { get; set; }
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }        
    }
}
