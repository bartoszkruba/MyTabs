using System.Collections.Generic;
using System.Linq;
using MyTabs.API.Model;

namespace MyTabs.API.Data
{
    public class SqlUsersRepo : IUsersRepo
    {
        private readonly MyTabsContext _context;

        public SqlUsersRepo(MyTabsContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException(nameof(SaveChanges));
        }

        public IEnumerable<User> GetAllUsers() => _context.Users.ToList();

        public User GetUserById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

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