using System.Linq;
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

        public SqlUserRepoTests()
        {
            _mockContext = new Mock<MyTabsContext>();
            _sqlUsersRepo = new SqlUsersRepo(_mockContext.Object);
        }

        [Fact]
        public void Test_GetUserById()
        {
            const int id = 1;
            const string username = "test1234";
            const string email = "test@email.com";
            const string password = "test1234";
            var user = new User(id, username, email, password);

            _mockContext.Setup(x => x.Users.FirstOrDefault(u => u.Id == id)).Returns(user);

            var returnedUser = _sqlUsersRepo.GetUserById(id);

            Assert.Equal(returnedUser, user);
            _mockContext.Verify(x => x.Users.FirstOrDefault(u => u.Id == id), Times.Once());
        }
    }
}