using AutoMapper;
using Moq;
using MyTabs.API.Controllers;
using MyTabs.API.Data;
using MyTabs.API.Dto;
using MyTabs.API.Model;
using Xunit;

namespace MyTabs.UnitTests.Controllers
{
    public class UsersControllerTests
    {
        private readonly UsersController _usersController;
        private readonly Mock<IUsersRepo> _mockUserRepo;
        private readonly Mock<IMapper> _mockMapper;

        public UsersControllerTests()
        {
            _mockUserRepo = new Mock<IUsersRepo>();
            _mockMapper = new Mock<IMapper>();
            _usersController = new UsersController(_mockUserRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public void Test_GetUserById()
        {
            // setup
            const int id = 1;
            const string username = "test1234";
            const string email = "test@email.com";
            const string password = "test1234";
            var user = new User(id, username, email, password);
            var userReadDto = new UserReadDto(id, username);

            _mockUserRepo.Setup(x => x.GetUserById(id)).Returns(user);
            _mockMapper.Setup(x => x.Map<UserReadDto>(user)).Returns(userReadDto);

            // actions
            var returnedUser = _usersController.GetUserById(id).Value;

            // asserts
            Assert.Equal(returnedUser, userReadDto);
            _mockUserRepo.Verify(x => x.GetUserById(id), Times.Once());
            _mockMapper.Verify(x => x.Map<UserReadDto>(user), Times.Once());
        }
    }
}