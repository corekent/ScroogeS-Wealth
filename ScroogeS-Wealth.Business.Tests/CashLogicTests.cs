using NUnit.Framework;
using ScroogeS_Wealth.Models;

namespace ScroogeS_Wealth.Business.Tests
{
    public class CashLogicTests
    {
        private CashLogic _cashLogic;
        [SetUp]
        public void Setup()
        {
            _cashLogic = new CashLogic();
        }

        [TestCase(0, "������", 450, 1)]
        public void CreateTest(int index, string name, decimal balance, int id)
        {
            Result<Cash> actual = _cashLogic.Create(name, balance, id);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "������", 450, 100)]
        public void NegativeCreateTest(int index, string name, decimal balance, int userId)
        {
            Result<Cash> actual = _cashLogic.Create(name, balance, userId);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }

        //[TestCase(1, 1, 1, "�������", 450)]
        //public void Remove(int index, int indexExp, int id, string name, decimal balance)
        //{
        //    //List<Cash> temp = CashTestData.GetListForTest(index);
        //    Result<Cash> temp = _cashLogic.Create(name, balance, id);
        //    Result<Cash> actual = _cashLogic.Remove(temp.Body.Id);
        //    Result<Cash> expected = CashTestData.GetResultForTest(indexExp);
        //    Assert.AreEqual(expected, actual);
        //}

        [TestCase(1,"������",450,"��� ��������", 1)]
        public void SetnameTest(int index, string name, decimal balance, string newName, int userId)
        {
            Result<Cash> temp = _cashLogic.Create(name, balance, userId);
            Result<Cash> actual = _cashLogic.SetName(temp.Body.Id, newName);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(2, "������", 450, 1450, 1)]
        public void SetBalanceTest(int index, string name, decimal balance, decimal newBalance, int userId)
        {
            Result<Cash> temp = _cashLogic.Create(name, balance, userId);
            Result<Cash> actual = _cashLogic.SetBalance(temp.Body.Id, newBalance);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            expected.Body.Id = actual.Body.Id;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("������", 450, 450, 1)]
        public void GetBalanceTest(string name, decimal balance, decimal expBalance, int userId)
        {
            Result<Cash> temp = _cashLogic.Create(name, balance, userId);
            decimal actual = _cashLogic.GetBalance(temp.Body.Id);
            decimal expected = expBalance;            
            Assert.AreEqual(expected, actual);
        }
    }
}