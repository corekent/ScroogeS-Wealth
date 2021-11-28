using Core;
using ScroogeS_Wealth.Business.HelpersStorage;
using ScroogeS_Wealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.Tests
{
    class IncomeTestData
    {
        public static Card GetCardForTests()
        {
            UserStorage user = new UserStorage();
            Result<User> temp = user.CreateUser("Mr.Nobody");
            int userID = temp.Body.Id;
            CardStorage card = new CardStorage();
            Result<Card> temp2 = card.Create("MagicCard", 2000, userID);
            Card card1 = temp2.Body;
            return card1;
        }

        public static Income GetIncomeForTest(int index)
        {
            DateTime date1 = new DateTime(2020, 2, 29);
            DateTime date2 = new DateTime(2021, 5, 29);
            DateTime date3 = DateTime.Now;
            Income income1 = new Income("Gift", 5000, date1);
            Income income2 = new Income("Deal", 50000, date2);
            Income income3 = new Income("Pay", 1450, date3);
            //Result<Income> temp1 = new Result<Income>(1, ServiceMessages.Created);
            //Result<Income> temp2 = new Result<Income>(1, ServiceMessages.nameChanged);
            //Result<Income> temp3 = new Result<Income>(1, ServiceMessages.summChanged);
            //Result<Income> temp4 = new Result<Income>(0, ServiceMessages.entityNotFound);
            return index switch
            {
                0 => income1,
                1 => income2,
                2 => income3,
                //3 => temp4,
                _ => throw new NotImplementedException(),
            };
        }
        public static Result<Income> GetResultForTest(int index)
        {
            DateTime date1 = new DateTime(2020, 2, 29);
            DateTime date2 = new DateTime(2021, 5, 29);
            DateTime date3 = DateTime.Now;
            Income income1 = new Income("Gift", 5000, date1);
            Income income2 = new Income("Deal", 50000, date2);
            Income income3 = new Income("Pay", 1450, date3);
            Result<Income> temp1 = new Result<Income>(1, ServiceMessages.incomeAdded);
            Result<Income> temp2 = new Result<Income>(1, ServiceMessages.nameChanged);
            Result<Income> temp3 = new Result<Income>(1, ServiceMessages.summChanged);
            Result<Income> temp4 = new Result<Income>(0, ServiceMessages.entityNotFound);
            return index switch
            {
                0 => temp1,
                1 => temp2,
                2 => temp3,
                3 => temp4,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
