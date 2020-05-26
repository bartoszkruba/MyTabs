using System.Collections.Generic;
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

        private const int IdOne = 1;
        private const string UsernameOne = "test1234";
        private const string EmailOne = "test@email.com";
        private const string PasswordOne = "test1234";
        private readonly User _userOne = new User(IdOne, UsernameOne, EmailOne, PasswordOne);
        private readonly UserReadDto _userReadDtoOne = new UserReadDto(IdOne, UsernameOne);
        private readonly UserCreateDto _userCreateDtoOne = new UserCreateDto(UsernameOne, EmailOne, PasswordOne);

        private const int IdTwo = 2;
        private const string UsernameTwo = "johndone";
        private const string EmailTwo = "john.doe@email.com";
        private const string PasswordTwo = "password1234";
        private readonly User _userTwo = new User(IdTwo, UsernameTwo, EmailTwo, PasswordTwo);
        private readonly UserReadDto _userReadDtoTwo = new UserReadDto(IdTwo, UsernameTwo);

        private const int IdThree = 3;
        private const string UsernameThree = "marydoe";
        private const string EmailThree = "mary.doe@email.com";
        private const string PasswordThree = "marydoe132";
        private readonly User _userThree = new User(IdThree, UsernameThree, EmailThree, PasswordThree);
        private readonly UserReadDto _userReadDtoThree = new UserReadDto(IdThree, UsernameThree);

        public UsersControllerTests()
        {
            _mockUserRepo = new Mock<IUsersRepo>();
            _mockMapper = new Mock<IMapper>();
            _usersController = new UsersController(_mockUserRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public void Test_GetUserById()
        {
            // preparation
            var userReadDto = new UserReadDto(IdOne, UsernameOne);
            _mockUserRepo.Setup(x => x.GetUserById(IdOne)).Returns(_userOne);
            _mockMapper.Setup(x => x.Map<UserReadDto>(_userOne)).Returns(userReadDto);

            // actions
            var response = _usersController.GetUserById(IdOne);
            var returnedUser = (response.Result as OkObjectResult)?.Value;

            // asserts
            Assert.Equal(200, ((OkObjectResult) response.Result).StatusCode);
            Assert.Equal(userReadDto, returnedUser);
            _mockUserRepo.Verify(x => x.GetUserById(IdOne), Times.Once());
            _mockUserRepo.VerifyNoOtherCalls();
            _mockMapper.Verify(x => x.Map<UserReadDto>(_userOne), Times.Once());
            _mockMapper.VerifyNoOtherCalls();
        }

        [Fact]
        public void Test_GetUserById_NotFound()
        {
            // preparation
            _mockUserRepo.Setup(x => x.GetUserById(IdOne)).Returns((User) null);

            // actions
            var response = _usersController.GetUserById(IdOne);

            // asserts
            Assert.Null(response.Value);
            Assert.Equal(404, ((StatusCodeResult) response.Result).StatusCode);
            _mockUserRepo.Verify(x => x.GetUserById(IdOne), Times.Once());
            _mockUserRepo.VerifyNoOtherCalls();

            _mockMapper.VerifyNoOtherCalls();
        }

        [Fact]
        public void Test_GetAllUsers()
        {
            // preparation
            var users = new List<User> {_userOne, _userTwo, _userThree};
            var dtos = new List<UserReadDto> {_userReadDtoOne, _userReadDtoTwo, _userReadDtoThree};
            _mockUserRepo.Setup(x => x.GetAllUsers()).Returns(users);
            _mockMapper.Setup(x => x.Map<IEnumerable<UserReadDto>>(users)).Returns(dtos);

            // actions
            var response = _usersController.GetAllUsers();
            var returnedUsers = (response.Result as OkObjectResult)?.Value as List<UserReadDto>;
            var responseStatus = ((OkObjectResult) response.Result).StatusCode;

            // asserts
            Assert.Equal(200, responseStatus);
            Assert.Equal(dtos, returnedUsers);
            Assert.Equal(3, returnedUsers!.Count);
            Assert.Contains(_userReadDtoOne, returnedUsers);
            Assert.Contains(_userReadDtoTwo, returnedUsers);
            Assert.Contains(_userReadDtoThree, returnedUsers);

            _mockUserRepo.Verify(x => x.GetAllUsers());
            _mockUserRepo.VerifyNoOtherCalls();

            _mockMapper.Verify(x => x.Map<IEnumerable<UserReadDto>>(users));
            _mockMapper.VerifyNoOtherCalls();
        }

        [Fact]
        public void Test_CreateNewUser()
        {
            // preparations
            _mockUserRepo.Setup(x => x.GetUserByEmailOrUsername(EmailOne, UsernameOne))
                .Returns((User) null);
            _mockMapper.Setup(x => x.Map<User>(_userCreateDtoOne)).Returns(_userOne);
            _mockMapper.Setup(x => x.Map<UserReadDto>(_userOne)).Returns(_userReadDtoOne);

            // actions
            var response = _usersController.CreateNewUser(_userCreateDtoOne);
            var returnedUser = (response.Result as CreatedAtActionResult)?.Value as UserReadDto;
            var responseStatus = (response.Result as CreatedAtActionResult)?.StatusCode;

            // asserts
            Assert.Equal(_userReadDtoOne, returnedUser);
            Assert.Equal(201, responseStatus);

            _mockUserRepo.Verify(x => x.GetUserByEmailOrUsername(EmailOne, UsernameOne), Times.Once());
            _mockMapper.Verify(x => x.Map<User>(_userReadDtoOne), Times.Once());
            _mockUserRepo.Verify(x => x.CreateUser(_userOne), Times.Once());
            _mockUserRepo.Verify(x => x.SaveChanges());
            _mockMapper.Verify(x => x.Map<UserReadDto>(_userOne), Times.Once());
            _mockUserRepo.VerifyNoOtherCalls();
            _mockMapper.VerifyNoOtherCalls();
        }

        [Fact]
        public void Test_CreateNewUser_UsernameOrEmailAlreadyExist()
        {
            // preparations
            _mockUserRepo.Setup(x => x.GetUserByEmailOrUsername(EmailOne, UsernameOne)).Returns(_userOne);

            // actions
            var response = _usersController.CreateNewUser(_userCreateDtoOne);
            var returnedBody = (response.Result as NotFoundObjectResult)?.Value as Dictionary<string, string>;
            var responseStatus = (response.Result as NotFoundObjectResult)?.StatusCode;

            // asserts
            Assert.Equal("400", returnedBody?["Status"]);
            Assert.Equal("Username or email is already taken", returnedBody?["Error"]);
            Assert.Equal(400, responseStatus);

            _mockUserRepo.Verify(x => x.GetUserByEmailOrUsername(EmailOne, UsernameOne));
            _mockUserRepo.VerifyNoOtherCalls();
            _mockMapper.VerifyNoOtherCalls();
        }
    }
}