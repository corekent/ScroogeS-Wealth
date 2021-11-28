using NUnit.Framework;
using ScroogeS_Wealth.Business.HelpersStorage;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System.Linq;

namespace ScroogeS_Wealth.Business.Tests
{
    public class CashStorageTests
    {

        private CashStorage _cashStorage = new CashStorage();
        private GenericStorage<User> _users = new GenericStorage<User>();
        [SetUp]
        public void Setup()
        {

        }
        public void tearDown()
        {
            var users = _users.Get();
            int id = users.Last().Id;
            _users.Remove(id);
        }




        [TestCase(0, "Кошель", 450)]
        public void CreateTest(int index, string name, decimal balance)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Cash> actual = _cashStorage.Create(name, balance, userId);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "Кошель", 450, 10000)]
        public void NegativeCreateTest(int index, string name, decimal balance, int userId)
        {
            Result<Cash> actual = _cashStorage.Create(name, balance, userId);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }



        [TestCase(1, "Кошель", 450, "Под подушкой")]
        public void SetnameTest(int index, string name, decimal balance, string newName)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Cash> temp = _cashStorage.Create(name, balance, userId);
            Result<Cash> actual = _cashStorage.SetName(temp.Body.Id, newName);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(2, "Кошель", 450, 1450)]
        public void SetBalanceTest(int index, string name, decimal balance, decimal newBalance)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Cash> temp = _cashStorage.Create(name, balance, userId);
            Result<Cash> actual = _cashStorage.SetBalance(temp.Body.Id, newBalance);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Кошель", 450, 450)]
        public void GetBalanceTest(string name, decimal balance, decimal expBalance)
        {
            User user = AccountTestData.GetUserForTests();
            int userId = user.Id;
            Result<Cash> temp = _cashStorage.Create(name, balance, userId);
            decimal actual = _cashStorage.GetBalance(temp.Body.Id);
            decimal expected = expBalance;            
            Assert.AreEqual(expected, actual);
        }
    }
}