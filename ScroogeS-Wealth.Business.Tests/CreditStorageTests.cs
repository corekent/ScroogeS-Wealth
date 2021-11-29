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
    public class CreditStorageTests
    {
        private CreditStorage _creditStorage = new CreditStorage();
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

        [TestCase(0, "Ipoteka", 100000, 1, 0, 1 , 0.1, "Ипотека")]
        public void CreateMortgageTest(int index, string name, decimal allSum, int userId, int idxDateStart, int idxDateEnd, double percent, string typeCredit)
        {
            User user = _users.Get().Last();
            userId = user.Id;
            DateTime dateStart = CreditTestData.GetDateForTest(idxDateStart);
            DateTime dateEnd = CreditTestData.GetDateForTest(idxDateEnd);
            Result<Credit> actual = _creditStorage.Create(name, allSum, userId, dateStart, dateEnd, percent, typeCredit);
            Result<Credit> expected = CreditTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(1, "Loan", 100000, 1, 0, 1, 0.1, "Кредит")]
        public void CreateLoanTest(int index, string name, decimal allSum, int userId, int idxDateStart, int idxDateEnd, double percent, string typeCredit)
        {
            User user = _users.Get().Last();
            userId = user.Id;
            DateTime dateStart = CreditTestData.GetDateForTest(idxDateStart);
            DateTime dateEnd = CreditTestData.GetDateForTest(idxDateEnd);
            Result<Credit> actual = _creditStorage.Create(name, allSum, userId, dateStart, dateEnd, percent, typeCredit);
            Result<Credit> expected = CreditTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(2, "InstallmentPayment", 100000, 1, 0, 1, 0.1, "Рассрочка")]
        public void CreateInstallmentPaymentTest(int index, string name, decimal allSum, int userId, int idxDateStart, int idxDateEnd, double percent, string typeCredit)
        {
            User user = _users.Get().Last();
            userId = user.Id;
            DateTime dateStart = CreditTestData.GetDateForTest(idxDateStart);
            DateTime dateEnd = CreditTestData.GetDateForTest(idxDateEnd);
            Result<Credit> actual = _creditStorage.Create(name, allSum, userId, dateStart, dateEnd, percent, typeCredit);
            Result<Credit> expected = CreditTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "InstallmentPayment", 100000, 0, 0, 1, 0.1, "Рассрочка")]
        public void CreateNegativeTest(int index, string name, decimal allSum, int userId, int idxDateStart, int idxDateEnd, double percent, string typeCredit)
        {            
            DateTime dateStart = CreditTestData.GetDateForTest(idxDateStart);
            DateTime dateEnd = CreditTestData.GetDateForTest(idxDateEnd);
            Result<Credit> actual = _creditStorage.Create(name, allSum, userId, dateStart, dateEnd, percent, typeCredit);
            Result<Credit> expected = CreditTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }
    }
}
