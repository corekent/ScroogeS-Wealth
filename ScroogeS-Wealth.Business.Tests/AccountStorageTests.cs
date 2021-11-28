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
    public class AccountStorageTests
    {
        private AccountStorage _accountStorage = new AccountStorage();
        private GenericStorage<User> _users = new GenericStorage<User>(); 
        [SetUp]
        public void Setup()
        {
            var users = _users.Get();
            int id = users.Last().Id;
            _users.Remove(id);
        }

        [TestCase(0, "My Precious", 20450)]
        public void CreateTest(int index, string name, decimal balance)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Account> actual = _accountStorage.Create(name, balance, userId);
            Result<Account> expected = AccountTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }

        //Метода нет такого
        //[TestCase(3, "MainAccount", 50550, 200000)]
        //public void NegativeCreateTest(int index, string name, decimal balance, int userId)
        //{
        //    Result<Account> actual = _accountStorage.Create(name, balance, userId);
        //    Result<Account> expected = AccountTestData.GetResultForTest(index);
        //    Assert.AreEqual(expected, actual);
        //}



        [TestCase(1, "MainAccount", 400350, "LovelyAccount")]
        public void SetnameTest(int index, string name, decimal balance, string newName)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Account> temp = _accountStorage.Create(name, balance, userId);
            Result<Account> actual = _accountStorage.SetName(temp.Body.Id, newName);
            Result<Account> expected = AccountTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, "My Precious", 4050, 1450)]
        public void SetBalanceTest(int index, string name, decimal balance, decimal newBalance)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Account> temp = _accountStorage.Create(name, balance, userId);
            Result<Account> actual = _accountStorage.SetBalance(temp.Body.Id, newBalance);
            Result<Account> expected = AccountTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("My Precious", 450, 450)]
        public void GetBalanceTest(string name, decimal balance, decimal expBalance)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Account> temp = _accountStorage.Create(name, balance, userId);
            decimal actual = _accountStorage.GetBalance(temp.Body.Id);
            decimal expected = expBalance;
            Assert.AreEqual(expected, actual);
        }
    }
}
