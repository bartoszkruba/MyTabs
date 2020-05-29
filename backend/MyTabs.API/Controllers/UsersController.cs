using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyTabs.API.Data;
using MyTabs.API.Dto;
using MyTabs.API.Dtos;
using MyTabs.API.Model;

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

        [HttpGet("{id}", Name = "GetUserById")]
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
            if (_usersRepo.GetUserByEmailOrUsername(userCreateDto.Email, userCreateDto.Username) != null)
            {
                var response = new Dictionary<string, string>
                {
                    ["Status"] = "400", ["Error"] = "Username or email is already taken."
                };
                return BadRequest(response);
            }

            var user = _mapper.Map<User>(userCreateDto);
            _usersRepo.CreateUser(user);
            _usersRepo.SaveChanges();

            return CreatedAtRoute(nameof(GetUserById), new {user.Id}, _mapper.Map<UserReadDto>(user));
        }

        [HttpPut("{id}")]
        public ActionResult<UserReadDto> UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var user = _usersRepo.GetUserById(id);
            if (user == null) return NotFound();

            if (user.Username != userUpdateDto.Username && _usersRepo.GetUserByUsername(userUpdateDto.Username) != null)
                return BadRequest(new Dictionary<string, string>
                    {["Status"] = "400", ["Error"] = "Username is already taken."});

            _mapper.Map(userUpdateDto, user);
            _usersRepo.UpdateUser(user);
            _usersRepo.SaveChanges();

            return Ok(_mapper.Map<UserReadDto>(user));
        }

        [HttpPatch("{id}")]
        public ActionResult<UserReadDto> UpdateUserPartly(int id, JsonPatchDocument<UserUpdateDto> patchDocument)
        {
            var user = _usersRepo.GetUserById(id);
            if (user == null) return NotFound();

            var updateDto = _mapper.Map<UserUpdateDto>(user);
            patchDocument.ApplyTo(updateDto, ModelState);
            if (!TryValidateModel(updateDto)) return ValidationProblem(ModelState);

            if (updateDto.Username != user.Username && _usersRepo.GetUserByUsername(updateDto.Username) != null)
                return BadRequest(new Dictionary<string, string>
                    {["Status"] = "400", ["Error"] = "Username is already taken."});

            _mapper.Map(updateDto, user);
            _usersRepo.UpdateUser(user);
            _usersRepo.SaveChanges();

            return Ok(_mapper.Map<UserReadDto>(user));
        }
    }
}