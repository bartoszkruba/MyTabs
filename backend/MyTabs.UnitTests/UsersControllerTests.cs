using AutoMapper;
using Moq;
using MyTabs.API.Controllers;
using MyTabs.API.Data;
using MyTabs.API.Dto;
using MyTabs.API.Model;
using Xunit;

namespace MyTabs.UnitTests
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
        }

        public void Test_GetUserById()
        {
            // setup
            int id = 1;
            string username = "test1234";
            string email = "test@email.com";
            string password = "test1234";
            var user = new User(id, username, email, password);
            var userReadDto = new UserReadDto(id, username);

            _mockUserRepo.Setup(x => x.GetUserById(id)).Returns(user);
            _mockMapper.Setup(x => x.Map<UserReadDto>(user)).Returns(userReadDto);

            // actions
            var returnedUser = _usersController.GetUserById(id);

            // asserts
            Assert.Equal(returnedUser, userReadDto);
        }
    }
}