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
    public class UserStorageTests
    {
        private UserStorage _userStorage = new UserStorage();
        private GenericStorage<User> _users = new GenericStorage<User>();
        [SetUp]
        public void Setup()
        {

        }
        [TestCase(1, "Mika")]
        public void CreateTest(int index, string name)
        {          
            Result<User> actual = _userStorage.CreateUser(name);
            Result<User> expected = UserTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(2, 1)]
        public void RemoveTest(int index, int id)
        {
            Result<User> actual = _userStorage.Remove(id);
            Result<User> expected = UserTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(3, 10)]
        public void RemoveNegativeTest(int index, int id)
        {
            Result<User> actual = _userStorage.Remove(id);
            Result<User> expected = UserTestData.GetResultForTest(index);
            Assert.AreEqual(expected, actual);
        }
    }
}
