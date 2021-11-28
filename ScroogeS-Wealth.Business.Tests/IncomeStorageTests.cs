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
    class IncomeStorageTests
    {
        private IncomeStorage<Card, Income> _incomeStorage = new IncomeStorage<Card, Income>();
        private GenericStorage<Card> _cards = new GenericStorage<Card>();
        [SetUp]
        public void Setup()
        {

        }
        public void tearDown()
        {
            var cards = _cards.Get();
            int id = cards.Last().Id;
            _cards.Remove(id);
        }

        [TestCase(0, "Gift", 5000)]
        public void CreateTest(int index, string name, decimal amount)
        {
            DateTime date1 = new DateTime(2020, 2, 29);
            Card card = IncomeTestData.GetCardForTests();
            int fromId = card.Id;
            Result<Income> actual = _incomeStorage.Create(name, amount, date1, fromId);
            Result<Income> expected = IncomeTestData.GetResultForTest(index);            
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "Gift", 5000, "Deal")]
        public void SetNameTest(int index, string name, decimal amount, string newName)
        {
            DateTime date1 = new DateTime(2020, 2, 29);
            Card card = IncomeTestData.GetCardForTests();
            int fromId = card.Id;
            _incomeStorage.Create(name, amount, date1, fromId);           
            //int incomeId = card.Incomes.Last().Id;
            Result<Income> actual = _incomeStorage.SetName(fromId, newName);
            Result<Income> expected = IncomeTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, "Gift", 5000, 10000)]
        public void SetAmountTest(int index, string name, decimal amount, decimal newAmount)
        {
            DateTime date1 = new DateTime(2020, 2, 29);
            Card card = IncomeTestData.GetCardForTests();
            int fromId = card.Id;
            Result<Income> temp = _incomeStorage.Create(name, amount, date1, fromId);
            Result<Income> actual = _incomeStorage.SetAmount(fromId, newAmount);
            Result<Income> expected = IncomeTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }

    }
}
