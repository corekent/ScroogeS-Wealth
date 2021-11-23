using Core;
using System.Collections.Generic;

namespace ScroogeS_Wealth.Models
{
    public class WorkSpace : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public List<Deposit> Deposits { get; set; } 
        public List<Account> Accounts { get; set; } 
        public List<Cash> Cash { get; set; } 
        public WorkSpace() 
        {
            Cards = new List<Card>();
            Deposits = new List<Deposit>();
            Accounts = new List<Account>();
            Cash = new List<Cash>();
        }
        public WorkSpace(int id, string name)
        {
            Id = id;
            Name = name;
            Cards = new List<Card>();
            Deposits = new List<Deposit>();
            Accounts = new List<Account>();
            Cash = new List<Cash>();
        }
    }
}
