using System.ComponentModel.DataAnnotations;

namespace backend.Dto
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
    }
}