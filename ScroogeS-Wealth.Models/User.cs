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
        public List<Credit> Credits { get; set; }
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
            Credits = new List<Credit>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            User m = obj as User;
            if (m as User == null)
                return false;
            return m.Name == Name;
        }
    }
}
