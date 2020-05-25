using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyTabs.API.Data;
using MyTabs.API.Model;
using Xunit;

namespace MyTabs.UnitTests.Repositories
{
    public class SqlUserRepoTests
    {
        private readonly SqlUsersRepo _sqlUsersRepo;
        private readonly Mock<MyTabsContext> _mockContext;
        private readonly Mock<DbSet<User>> _mockSet;

        private const int IdOne = 1;
        private const string UsernameOne = "test1234";
        private const string EmailOne = "test@email.com";
        private const string PasswordOne = "test1234";
        private readonly User _userOne = new User(IdOne, UsernameOne, EmailOne, PasswordOne);

        private const int IdTwo = 2;
        private const string UsernameTwo = "johndone";
        private const string EmailTwo = "john.doe@email.com";
        private const string PasswordTwo = "password1234";
        private readonly User _userTwo = new User(IdTwo, UsernameTwo, EmailTwo, PasswordTwo);

        private const int IdThree = 3;
        private const string UsernameThree = "marydoe";
        private const string EmailThree = "mary.doe@email.com";
        private const string PasswordThree = "marydoe132";
        private readonly User _userThree = new User(IdThree, UsernameThree, EmailThree, PasswordThree);

        public SqlUserRepoTests()
        {
            var data = new List<User> {_userOne, _userTwo, _userThree}.AsQueryable();
            _mockSet = new Mock<DbSet<User>>();
            _mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            _mockContext = new Mock<MyTabsContext>();
            _mockContext.Setup(c => c.Users).Returns(_mockSet.Object);

            _sqlUsersRepo = new SqlUsersRepo(_mockContext.Object);
        }

        [Fact]
        public void Test_GetUserById()
        {
            var returnedUser = _sqlUsersRepo.GetUserById(IdOne);

            _mockContext.Verify(x => x.Users, Times.Once());
            Assert.Equal(returnedUser, _userOne);
        }

        [Fact]
        public void Test_GetUserById_No_Match()
        {
            var returnedUser = _sqlUsersRepo.GetUserById(1231214);
            _mockContext.Verify(x => x.Users, Times.Once());
            Assert.Null(returnedUser);
        }

        [Fact]
        public void Test_GetAllUsers()
        {
            // actions
            var users = _sqlUsersRepo.GetAllUsers();

            // asserts
            var enumerable = users as User[] ?? users.ToArray();
            Assert.Equal(3, enumerable.Count());
            Assert.Contains(_userOne, enumerable);
            Assert.Contains(_userTwo, enumerable);
            Assert.Contains(_userThree, enumerable);
            _mockContext.Verify(x => x.Users, Times.Once());
        }
    }
}