using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Model
{
    public class User
    {
        [Key] public int Id { get; set; }

        [Required, MinLength(4), MaxLength(20)]
        public string Username { get; set; }

        [Required, EmailAddress] public string Email { get; set; }


        [Required] public string Password { get; set; }
    }
}