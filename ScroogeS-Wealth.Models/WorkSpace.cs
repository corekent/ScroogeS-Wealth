using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class WorkSpace
    {
        public User GeneralUser { get; set; }
        public List<Card> Cards { get; set; }
        public List<Deposit> Deposits { get; set; }
        public List<Account> Accounts { get; set; }
        public Cash Cash { get; set; }
        
        public WorkSpace(User user)
        {
            GeneralUser = user;
        }
    }
}
