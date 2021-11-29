using Core;
using System.Collections.Generic;

namespace ScroogeS_Wealth.Models
{
    public abstract class AssetModel : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
        public List<Expense> Expenses { get; set; } = new List<Expense>();

        public List<Income> Incomes { get; set; } = new List<Income>();
    }
}
