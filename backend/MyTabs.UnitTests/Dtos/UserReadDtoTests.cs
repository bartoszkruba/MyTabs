using MyTabs.API.Dto;
using Xunit;

namespace MyTabs.UnitTests.Dtos
{
    public class UserReadDtoTests
    {
        private const int Id = 1;
        private const string Username = "test1234";

        [Fact]
        public void Test_Equals_Positive()
        {
            var userOne = new UserReadDto(Id, Username);
            var userTwo = new UserReadDto(Id, Username);

            Assert.True(userOne.Equals(userTwo));
            Assert.True(userTwo.Equals(userOne));
        }

        [Fact]
        public void Test_Equals_Negative()
        {
            var userOne = new UserReadDto(Id, Username);
            var userTwo = new UserReadDto(213312, Username);
            var userThree = new UserReadDto(Id, "sddadas");

            Assert.False(userOne.Equals(userTwo));
            Assert.False(userTwo.Equals(userOne));

            Assert.False(userOne.Equals(userThree));
            Assert.False(userThree.Equals(userOne));
        }
    }
}