using MyTabs.API.Dtos;
using Xunit;

namespace MyTabs.UnitTests.Dtos
{
    public class UserUpdateDtoTests
    {
        private const string Username = "test1234";
        private const string Password = "test1234";

        [Fact]
        public void Test_Equals_Positive()
        {
            var userOne = new UserUpdateDto(Username, Password);
            var userTwo = new UserUpdateDto(Username, Password);

            Assert.True(userOne.Equals(userTwo));
            Assert.True(userTwo.Equals(userOne));
        }

        [Fact]
        public void Test_Equals_Negative()
        {
            var userOne = new UserUpdateDto(Username, Password);
            var userTwo = new UserUpdateDto("sadadssdaads", Password);
            var userThree = new UserUpdateDto(Username, "dsaadsdasas");

            Assert.False(userOne.Equals(userTwo));
            Assert.False(userTwo.Equals(userOne));

            Assert.False(userOne.Equals(userThree));
            Assert.False(userThree.Equals(userOne));
        }
    }
}