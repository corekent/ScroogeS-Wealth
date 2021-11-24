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

        [TestCase(0, "Подушка", 450, 0)]
        public void Create(int index, string name, decimal balance, int id)
        {
            Result<Cash> actual = _cashLogic.Create(name, balance, id);
            Result<Cash> expected = CashTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(1, 1, 1, "Подушка", 450)]
        public void Remove(int index, int indexExp, int id, string name, decimal balance)
        {
            //List<Cash> temp = CashTestData.GetListForTest(index);
            Result<Cash> temp = _cashLogic.Create(name, balance, id);
            Result<Cash> actual = _cashLogic.Remove(temp.Body.Id);
            Result<Cash> expected = CashTestData.GetResultForTest(indexExp);
            Assert.AreEqual(expected, actual);
        }
    }
}