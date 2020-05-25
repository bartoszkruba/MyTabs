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

        public SqlUserRepoTests()
        {
            var data = new List<User> {_userOne}.AsQueryable();
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
            _mockContext.VerifyNoOtherCalls();
            Assert.Equal(returnedUser, _userOne);
        }

        [Fact]
        public void Test_GetUserById_No_Match()
        {
            var returnedUser = _sqlUsersRepo.GetUserById(1231214);
            _mockContext.Verify(x => x.Users, Times.Once());
            _mockContext.VerifyNoOtherCalls();
            Assert.Null(returnedUser);
        }
    }
}