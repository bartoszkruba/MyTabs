using System;

namespace MyTabs.API.Dto
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public UserReadDto()
        {
        }

        public UserReadDto(int id, string username)
        {
            Id = id;
            Username = username;
        }

        protected bool Equals(UserReadDto other)
        {
            return Id == other.Id && Username == other.Username;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserReadDto) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Username);
        }
    }
}