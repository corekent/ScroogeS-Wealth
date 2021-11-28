using NUnit.Framework;
using ScroogeS_Wealth.Business.HelpersStorage;
using ScroogeS_Wealth.Models;
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

        [SetUp]
        public void Setup()
        {
            _depositStorage = new DepositStorage();
        }

        [TestCase(0, "Накопительный", 210000, 1)]
        public void CreateTest(int idx, string name, decimal balance, int userId)
        {
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

        [TestCase(1, "Накопительный", 210000, "На тачку", 1)]
        public void SetnameTest(int index, string name, decimal balance, string newName, int userId)
        {
            Result<Deposit> temp = _depositStorage.Create(name, balance, userId);
            Result<Deposit> actual = _depositStorage.SetName(temp.Body.Id, newName);
            Result<Deposit> expected = DepositTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, "Накопительный", 210000, 85000, 1)]
        public void SetBalanceTest(int index, string name, decimal balance, decimal newBalance, int userId)
        {
            Result<Deposit> temp = _depositStorage.Create(name, balance, userId);
            Result<Deposit> actual = _depositStorage.SetBalance(temp.Body.Id, newBalance);
            Result<Deposit> expected = DepositTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Накопительный", 210000, 210000, 1)]
        public void GetBalanceTest(string name, decimal balance, decimal expBalance, int userId)
        {
            Result<Deposit> temp = _depositStorage.Create(name, balance, userId);
            decimal actual = _depositStorage.GetBalance(temp.Body.Id);
            decimal expected = expBalance;
            Assert.AreEqual(expected, actual);
        }
    }
}
