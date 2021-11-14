using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class IncomesLogic
    {
        public void Add(decimal sum, Card cardName, DateTime time )
        {
            Incomes newIncome = new Incomes(sum, cardName, time);
            IncomesStorage.Incomes.Add(newIncome);
        }
        public void Set(decimal sum)
        {
            int index=IncomesStorage.Incomes.Count-1;
            IncomesStorage.Incomes[index].Amount = sum;
        }
        public void Set(Card cardName)
        {
            int index = IncomesStorage.Incomes.Count-1;
            IncomesStorage.Incomes[index].ToCard = cardName;
        }
        public void Set(DateTime time)
        {
            int index = IncomesStorage.Incomes.Count - 1;
            IncomesStorage.Incomes[index].Date = time;
        }
        public void DeleteLast()
        {
            int index = IncomesStorage.Incomes.Count - 1;
            IncomesStorage.Incomes.RemoveAt(index);
        }
        //продумать поступление постоянного дохода.Константы? If time==fixtime? Или в аналитику?
        public void AddPermanentIncome(decimal fixSum, Card cardName, DateTime fixTime)
        {
            Incomes fixIncome = new Incomes(fixSum, cardName, fixTime);
            IncomesStorage.Incomes.Add(fixIncome);
        }

    }
}
