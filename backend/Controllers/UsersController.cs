using System;
using System.Collections.Generic;
using backend.Data;
using backend.Dto;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController, Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUsersRepo _usersRepo;

        public UsersController(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            throw new NotImplementedException(nameof(GetAllUsers));
        }

        [HttpGet("{id}")]
        public ActionResult<UserReadDto> GetUserById()
        {
            throw new NotImplementedException(nameof(GetUserById));
        }

        [HttpPost]
        public ActionResult<UserReadDto> CreateNewUser()
        {
            throw new NotImplementedException(nameof(CreateNewUser));
        }
    }
}