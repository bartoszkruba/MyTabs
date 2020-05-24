using MyTabs.API.Dto;
using Xunit;

namespace MyTabs.UnitTests.Dtos
{
    public class UserCreateDtoTests
    {
        private const string Username = "test1234";
        private const string Email = "test@email.com";
        private const string Password = "test1234";

        [Fact]
        public void Test_Equals_Positive()
        {
            var userOne = new UserCreateDto(Username, Email, Password);
            var userTwo = new UserCreateDto(Username, Email, Password);

            Assert.True(userOne.Equals(userTwo));
            Assert.True(userTwo.Equals(userOne));
        }

        [Fact]
        public void Test_Equals_Negative()
        {
        }
    }
}