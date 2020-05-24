using System;
using System.ComponentModel.DataAnnotations;

namespace MyTabs.API.Model
{
    public class User
    {
        [Key] public int Id { get; set; }

        [Required, MinLength(4), MaxLength(20)]
        public string Username { get; set; }

        [Required, EmailAddress] public string Email { get; set; }

        [Required] public string Password { get; set; }

        public User()
        {
        }

        public User(int id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }

        protected bool Equals(User other)
        {
            return Id == other.Id && Username == other.Username && Email == other.Email && Password == other.Password;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Username, Email, Password);
        }
    }
}