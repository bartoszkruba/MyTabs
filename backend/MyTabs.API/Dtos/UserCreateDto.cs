using System;
using System.ComponentModel.DataAnnotations;

namespace MyTabs.API.Dto
{
    public class UserCreateDto
    {
        [Required,
         MinLength(4),
         MaxLength(20)]
        public string Username { get; set; }

        [Required,
         EmailAddress]
        public string Email { get; set; }

        [Required
        ]
        public string Password { get; set; }

        public UserCreateDto()
        {
        }

        public UserCreateDto(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        protected bool Equals(UserCreateDto other)
        {
            return Username == other.Username && Email == other.Email && Password == other.Password;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserCreateDto) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Email, Password);
        }
    }
}