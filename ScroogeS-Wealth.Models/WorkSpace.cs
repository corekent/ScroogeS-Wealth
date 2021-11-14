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
        public List<Card> Cards { get; set; } = new List<Card>();
        public List<Deposit> Deposits { get; set; } = new List<Deposit>();
        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Cash> Cash { get; set; } = new List<Cash>();
        
        public WorkSpace(User user)
        {
            GeneralUser = user;
        }
    }
}
