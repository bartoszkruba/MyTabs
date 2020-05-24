using MyTabs.API.Model;
using Xunit;

namespace MyTabs.UnitTests.Models
{
    public class UserTests
    {
        private const int Id = 1;
        private const string Username = "test1234";
        private const string Email = "test@email.com";
        private const string Password = "test1234";

        [Fact]
        public void Test_Equals_Positive()
        {
            var userOne = new User(Id, Username, Email, Password);
            var userTwo = new User(Id, Username, Email, Password);

            Assert.True(userOne.Equals(userTwo));
            Assert.True(userTwo.Equals(userOne));
        }

        [Fact]
        public void Test_Equals_Negative()
        {
            var userOne = new User(Id, Username, Email, Password);
            var userTwo = new User(123, Username, Email, Password);
            var userThree = new User(Id, "sadsads", Email, Password);
            var userFour = new User(Id, Username, "dsdsffs@gmail.com", Password);
            var userFive = new User(Id, Username, Email, "sadassdsa");

            Assert.False(userOne.Equals(userTwo));
            Assert.False(userTwo.Equals(userOne));

            Assert.False(userOne.Equals(userThree));
            Assert.False(userThree.Equals(userOne));

            Assert.False(userOne.Equals(userFour));
            Assert.False(userFour.Equals(userOne));

            Assert.False(userOne.Equals(userFive));
            Assert.False(userFive.Equals(userOne));
        }
    }
}