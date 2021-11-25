using Core;
using System.Collections.Generic;

namespace ScroogeS_Wealth.Models
{
    public class User : IBaseModel
    {     
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<Card> Cards { get; set; }
        public List<Deposit> Deposits { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Cash> Cash { get; set; }

        public User(string name)
        {
            Name = name;
            Cards = new List<Card>();
            Deposits = new List<Deposit>();
            Accounts = new List<Account>();
            Cash = new List<Cash>();
        }
    }
}
