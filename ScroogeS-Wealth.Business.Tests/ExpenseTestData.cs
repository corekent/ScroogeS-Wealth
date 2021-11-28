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
    public class ExpenseTestData
    {
        public static Cash GetCashForTests()
        {
            UserStorage user = new UserStorage();
            Result<User> temp = user.CreateUser("Mr.Nobody");
            int userID = temp.Body.Id;
            CashStorage cash = new CashStorage();
            Result<Cash> temp2 = cash.Create("BigBag", 2000, userID);
            Cash cash1 = temp2.Body;
            return cash1;
        }

        public static Expense GetExpenseForTest(int index)
        {
            DateTime date1 = new DateTime(2020, 3, 01);
            DateTime date2 = new DateTime(2021, 9, 29);
            DateTime date3 = DateTime.Now;
            Expense expense1 = new Expense("Party", 5000, date1);
            Expense expense2 = new Expense("Dress", 50000, date2);
            Expense expense3 = new Expense("College", 1450, date3);           
            return index switch
            {
                0 => expense1,
                1 => expense2,
                2 => expense3,
                //3 => temp4,
                _ => throw new NotImplementedException(),
            };
        }
        public static Result<Expense> GetResultForTest(int index)
        {
            DateTime date1 = new DateTime(2020, 3, 01);
            DateTime date2 = new DateTime(2021, 9, 29);
            DateTime date3 = DateTime.Now;
            Expense expense1 = new Expense("Party", 5000, date1);
            Expense expense2 = new Expense("Dress", 50000, date2);
            Expense expense3 = new Expense("College", 1450, date3);
            Result<Expense> temp1 = new Result<Expense>(1, ServiceMessages.expenseAdded);
            Result<Expense> temp2 = new Result<Expense>(1, ServiceMessages.nameChanged);
            Result<Expense> temp3 = new Result<Expense>(1, ServiceMessages.summChanged);
            Result<Expense> temp4 = new Result<Expense>(0, ServiceMessages.entityNotFound);
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
