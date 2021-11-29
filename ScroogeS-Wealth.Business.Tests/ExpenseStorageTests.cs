using NUnit.Framework;
using ScroogeS_Wealth.Business.HelpersStorage;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business.Tests
{
   public class ExpenseStorageTests
    {
        private ExpenseStorage<Cash, Expense> _expenseStorage = new ExpenseStorage<Cash, Expense>();
        private GenericStorage<Cash> _cashes = new GenericStorage<Cash>();
        [SetUp]
        public void Setup()
        {

        }
        public void tearDown()
        {
            var cards = _cashes.Get();
            int id = cards.Last().Id;
            _cashes.Remove(id);
        }

        [TestCase(0, "Party", 5000)]
        public void CreateTest(int index, string name, decimal amount)
        {
            DateTime date1 = new DateTime(2020, 3, 01);
            Cash cash = ExpenseTestData.GetCashForTests();
            int fromId = cash.Id;
            Result<Expense> actual = _expenseStorage.Create(name, amount, date1, fromId);
            Result<Expense> expected = ExpenseTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "Party", 5000, "Dress")]
        public void SetNameTest(int index, string name, decimal amount, string newName)
        {
            DateTime date1 = new DateTime(2020, 2, 29);
            Cash cash = ExpenseTestData.GetCashForTests();
            int fromId = cash.Id;
            _expenseStorage.Create(name, amount, date1, fromId);
            Result<Expense> actual = _expenseStorage.SetName(fromId, newName);
            Result<Expense> expected = ExpenseTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, "Party", 5000, 10000)]
        public void SetAmountTest(int index, string name, decimal amount, decimal newAmount)
        {
            DateTime date1 = new DateTime(2020, 2, 29);
            Cash cash = ExpenseTestData.GetCashForTests();
            int fromId = cash.Id;
            Result<Expense> temp = _expenseStorage.Create(name, amount, date1, fromId);
            Result<Expense> actual = _expenseStorage.SetAmount(fromId, newAmount);
            Result<Expense> expected = ExpenseTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }
    }
}
