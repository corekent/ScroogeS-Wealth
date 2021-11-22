using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class WorkSpace : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User GeneralUser { get; set; }
        public List<Card> Cards { get; set; }
        public List<Deposit> Deposits { get; set; } 
        public List<Account> Accounts { get; set; } 
        public List<Cash> Cash { get; set; } 
        
        public WorkSpace(User user)
        {
            GeneralUser = user;
            Cards  = new List<Card>();
            Deposits = new List<Deposit>();
            Accounts = new List<Account>();
            Cash = new List<Cash>();
        }
    }
}
