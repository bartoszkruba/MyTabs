using System.Collections.Generic;
using backend.Model;

namespace backend.Data
{
    public class SqlUsersRepo : IUsersRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException(nameof(SaveChanges));
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new System.NotImplementedException(nameof(GetAllUsers));
        }

        public User GetUserById()
        {
            throw new System.NotImplementedException(nameof(GetUserById));
        }

        public User GetUserByEmailOrUsername(string email, string username)
        {
            throw new System.NotImplementedException(nameof(GetUserByEmailOrUsername));
        }

        public void CreateUser(User user)
        {
            throw new System.NotImplementedException(nameof(CreateUser));
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException(nameof(UpdateUser));
        }
    }
}