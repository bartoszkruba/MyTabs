using System.Collections.Generic;
using backend.Model;

namespace backend.Data
{
    public interface IUsersRepo
    {
        bool SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById();
        User GetUserByEmailOrUsername(string email, string username);
        void CreateUser(User user);
    }
}