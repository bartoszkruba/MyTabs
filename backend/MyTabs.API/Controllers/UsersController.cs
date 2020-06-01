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

        /// <summary>Get all users.</summary>
        /// <returns>List of existing users.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/users
        /// </remarks>
        /// <response code="200">Returns list of all existing users.</response>
        /// <response code="500">Server error.</response>
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var users = _usersRepo.GetAllUsers();

            var userDtos = _mapper.Map<IEnumerable<UserReadDto>>(users);
            return Ok(userDtos);
        }

        /// <summary>Get user by id.</summary>
        /// <param name="id"></param>
        /// <returns>User with specified id.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/users/1
        /// </remarks>
        /// <response code="200">Returns user with specified id.</response>
        /// <response code="404">User with specified id does not exist.</response>
        /// <response code="500">Server error.</response>
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var user = _usersRepo.GetUserById(id);
            if (user == null) return NotFound();

            var userReadDto = _mapper.Map<UserReadDto>(user);
            return Ok(userReadDto);
        }

        /// <summary>Create new user.</summary>
        /// <param name="userCreateDto"></param>
        /// <returns>A newly created user.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/users
        ///     {
        ///         "username": "johndoe69",
        ///         "email": "john.doe@email.com",
        ///         "password": "password123"
        ///     }
        /// </remarks>
        /// <response code="201">Returns the newly created user.</response>
        /// <response code="400">Validation error / Username or email is already taken.</response>
        /// <response code="500">Server error.</response> 
        [HttpPost]
        [ProducesResponseType(typeof(UserCreateDto), 201)] // removes the default 200 response code
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

        /// <summary>Update a specific user.</summary>
        /// <param name="id"></param>
        /// <param name="userUpdateDto"></param>
        /// <returns>Updated User.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// PUT /api/users/1
        /// {
        ///     "username": "new_username"
        ///     "password": "newPassword123"
        /// }
        /// </remarks>
        /// <response code="200">Returns newly updated user.</response>
        /// <response code="404">User with specified id does not exist.</response>
        /// <response code="400">Validation error / Cannot update user because username is already taken by some other user.</response>
        /// <response code="500">Server error.</response>
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

        /// <summary>
        /// Patch a specific user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDocument"></param>
        /// <returns>Patched user.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /api/users/1
        ///     {
        ///       [
        ///         {
        ///           "op": "replace",
        ///           "path": "/username",
        ///           "value": "newUsername"
        ///         },
        ///         {
        ///           "op": "replace",
        ///           "path": "/password",
        ///           "value": "newPassword"  
        ///         },
        ///         {
        ///           "op": "test",
        ///           "path": "/username",
        ///           "value": "newUsername"
        ///         },
        ///         {
        ///           "op": "test",
        ///           "path": "/password",
        ///           "value": "newPassword"
        ///         }
        ///       ]
        ///     } 
        /// </remarks>
        /// <response code="200">Returns newly patched user.</response>
        /// <response code="401">User with specified id does not exist.</response>
        /// <response code="400">Validation error / Cannot update user because username is already taken by some other user.</response>
        /// <response code="500">Server error.</response>
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