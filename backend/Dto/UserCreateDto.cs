using System.ComponentModel.DataAnnotations;

namespace backend.Dto
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
    }
}