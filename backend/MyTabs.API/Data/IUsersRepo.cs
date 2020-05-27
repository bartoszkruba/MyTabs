using System.Collections.Generic;
using MyTabs.API.Model;

namespace MyTabs.API.Data
{
    public interface IUsersRepo
    {
        bool SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmailOrUsername(string email, string username);
        User GetUserByUsername(string username);
        void CreateUser(User user);
        void UpdateUser(User user);
    }
}