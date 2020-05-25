using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        private const int Id = 1;
        private const string Username = "test1234";
        private const string Email = "test@email.com";
        private const string Password = "test1234";
        private readonly User _userOne = new User(Id, Username, Email, Password);

        public UsersControllerTests()
        {
            _mockUserRepo = new Mock<IUsersRepo>();
            _mockMapper = new Mock<IMapper>();
            _usersController = new UsersController(_mockUserRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public void Test_GetUserById()
        {
            var userReadDto = new UserReadDto(Id, Username);

            _mockUserRepo.Setup(x => x.GetUserById(Id)).Returns(_userOne);
            _mockMapper.Setup(x => x.Map<UserReadDto>(_userOne)).Returns(userReadDto);

            // actions
            var response = _usersController.GetUserById(Id);
            var returnedUser = (response.Result as OkObjectResult)?.Value;

            // asserts
            Assert.Equal(200, ((OkObjectResult) response.Result).StatusCode);
            Assert.Equal(userReadDto, returnedUser);
            _mockUserRepo.Verify(x => x.GetUserById(Id), Times.Once());
            _mockUserRepo.VerifyNoOtherCalls();
            _mockMapper.Verify(x => x.Map<UserReadDto>(_userOne), Times.Once());
            _mockMapper.VerifyNoOtherCalls();
        }

        [Fact]
        public void Test_GetUserById_NotFound()
        {
            _mockUserRepo.Setup(x => x.GetUserById(Id)).Returns((User) null);

            var response = _usersController.GetUserById(Id);
            Assert.Null(response.Value);
            Assert.Equal(404, ((StatusCodeResult) response.Result).StatusCode);

            _mockUserRepo.Verify(x => x.GetUserById(Id), Times.Once());
            _mockUserRepo.VerifyNoOtherCalls();

            _mockMapper.VerifyNoOtherCalls();
        }
    }
}