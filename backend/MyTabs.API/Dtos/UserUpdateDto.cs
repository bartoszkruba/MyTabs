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
    }
}