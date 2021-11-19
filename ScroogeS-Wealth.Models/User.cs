using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class User : BaseModel
    {
        public User(string name)
        {
            Name = name;
        }        
    }
}
