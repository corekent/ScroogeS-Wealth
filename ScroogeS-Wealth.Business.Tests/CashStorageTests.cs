using NUnit.Framework;
using ScroogeS_Wealth.Business.HelpersStorage;
using ScroogeS_Wealth.Models;

namespace ScroogeS_Wealth.Business.Tests
{
    public class CashStorageTests
    {
        private CashStorage _cashStorage;
        private UserStorage _user;
        [SetUp]
        public void Setup()
        {
            _cashStorage = new CashStorage();
            _user = new UserStorage();
            _user.CreateUser("Mr.Nobody");
        }

        [TestCase(0, "Кошель", 450, 1)]
        public void CreateTest(int index, string name, decimal balance, int id)
        {
            Result<Cash> actual = _cashStorage.Create(name, balance, id);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "Кошель", 450, 100)]
        public void NegativeCreateTest(int index, string name, decimal balance, int userId)
        {
            Result<Cash> actual = _cashStorage.Create(name, balance, userId);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }

        

        [TestCase(1,"Кошель",450,"Под подушкой", 1)]
        public void SetnameTest(int index, string name, decimal balance, string newName, int userId)
        {
            Result<Cash> temp = _cashStorage.Create(name, balance, userId);
            Result<Cash> actual = _cashStorage.SetName(temp.Body.Id, newName);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(2, "Кошель", 450, 1450, 1)]
        public void SetBalanceTest(int index, string name, decimal balance, decimal newBalance, int userId)
        {
            Result<Cash> temp = _cashStorage.Create(name, balance, userId);
            Result<Cash> actual = _cashStorage.SetBalance(temp.Body.Id, newBalance);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Кошель", 450, 450, 1)]
        public void GetBalanceTest(string name, decimal balance, decimal expBalance, int userId)
        {
            Result<Cash> temp = _cashStorage.Create(name, balance, userId);
            decimal actual = _cashStorage.GetBalance(temp.Body.Id);
            decimal expected = expBalance;            
            Assert.AreEqual(expected, actual);
        }
    }
}