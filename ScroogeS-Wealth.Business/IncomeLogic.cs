using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class IncomeLogic
    {
        public Result<Incomes> Add(string name, decimal amount, int cardId, DateTime time)
        {
            int lastId;

            Incomes income = new Incomes(name, amount, time);

            if (IncomesStorage.Incomes.Count == 0)
                lastId = 1;
            else
                lastId = IncomesStorage.Incomes.Last().Id + 1;

            income.Id = lastId;
            var card = CardStorage.Cards.FirstOrDefault(x => x.Id == cardId);

            if (card is null)
            {
                return new Result<Incomes>(0, "Карта не найдена");
            }

            income.Card = card;

            IncomesStorage.Incomes.Add(income);
            if (card.Balance >= amount)
            {
                card.Balance -= amount;
                return new Result<Incomes>(1, income, "Расход учтён");
            }
            else
            {
                return new Result<Incomes>(0, income, "на карте меньше нуля");
            }

        }
    }
}

