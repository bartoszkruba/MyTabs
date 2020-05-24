using System;
using System.ComponentModel.DataAnnotations;

namespace MyTabs.API.Dtos
{
    public class UserUpdateDto
    {
        [Required,
         MinLength(4),
         MaxLength(20)]
        public string Username { get; set; }

        [Required
        ]
        public string Password { get; set; }

        public UserUpdateDto()
        {
        }

        public UserUpdateDto(string username, string password)
        {
            Username = username;
            Password = password;
        }

        protected bool Equals(UserUpdateDto other)
        {
            return Username == other.Username && Password == other.Password;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserUpdateDto) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Password);
        }
    }
}