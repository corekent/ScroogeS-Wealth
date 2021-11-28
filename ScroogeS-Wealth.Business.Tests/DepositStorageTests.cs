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
    class DepositStorageTests
    {
        private DepositStorage _depositStorage;
        private GenericStorage<User> _users = new GenericStorage<User>();

        [SetUp]
        public void Setup()
        {
            _depositStorage = new DepositStorage();
        }
        public void tearDown()
        {
            var users = _users.Get();
            int id = users.Last().Id;
            _users.Remove(id);
        }

        [TestCase(0, "Накопительный", 210000)]
        public void CreateTest(int idx, string name, decimal balance)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Deposit> actual = _depositStorage.Create(name, balance, userId);
            Result<Deposit> expected = DepositTestData.GetResultForTest(idx);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "Накопительный", 210000, 0)]
        public void NegativeCreateTest(int idx, string name, decimal balance, int userId)
        {
            Result<Deposit> actual = _depositStorage.Create(name, balance, userId);
            Result<Deposit> expected = DepositTestData.GetResultForTest(idx);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "Накопительный", 210000, "На тачку")]
        public void SetnameTest(int index, string name, decimal balance, string newName)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Deposit> temp = _depositStorage.Create(name, balance, userId);
            Result<Deposit> actual = _depositStorage.SetName(temp.Body.Id, newName);
            Result<Deposit> expected = DepositTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, "Накопительный", 210000, 85000)]
        public void SetBalanceTest(int index, string name, decimal balance, decimal newBalance)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Deposit> temp = _depositStorage.Create(name, balance, userId);
            Result<Deposit> actual = _depositStorage.SetBalance(temp.Body.Id, newBalance);
            Result<Deposit> expected = DepositTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Накопительный", 210000, 210000)]
        public void GetBalanceTest(string name, decimal balance, decimal expBalance)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Deposit> temp = _depositStorage.Create(name, balance, userId);
            decimal actual = _depositStorage.GetBalance(temp.Body.Id);
            decimal expected = expBalance;
            Assert.AreEqual(expected, actual);
        }
    }
}
