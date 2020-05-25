using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyTabs.API.Data;
using MyTabs.API.Dto;
using MyTabs.API.Dtos;

namespace MyTabs.API.Controllers
{
    [ApiController, Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUsersRepo _usersRepo;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepo usersRepo, IMapper mapper)
        {
            _mapper = mapper;
            _usersRepo = usersRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var users = _usersRepo.GetAllUsers();

            var userDtos = _mapper.Map<IEnumerable<UserReadDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var user = _usersRepo.GetUserById(id);
            if (user == null) return NotFound();

            var userReadDto = _mapper.Map<UserReadDto>(user);
            return Ok(userReadDto);
        }

        [HttpPost]
        public ActionResult<UserReadDto> CreateNewUser(UserCreateDto userCreateDto)
        {
            throw new NotImplementedException(nameof(CreateNewUser));
        }

        [HttpPut("{id}")]
        public ActionResult<UserReadDto> UpdateUser(int id, UserCreateDto userCreateDto)
        {
            throw new NotImplementedException(nameof(UpdateUser));
        }

        [HttpPatch("{id}")]
        public ActionResult<UserReadDto> UpdateUserPartly(int id, JsonPatchDocument<UserUpdateDto> patchDocument)
        {
            throw new NotImplementedException(nameof(UpdateUserPartly));
        }
    }
}