using System;
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

        public bool SaveChanges() => _context.SaveChanges() >= 0;

        public IEnumerable<User> GetAllUsers() => _context.Users.ToList();

        public User GetUserById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

        public User GetUserByEmailOrUsername(string email, string username)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            if (username == null) throw new ArgumentNullException(nameof(username));

            return _context.Users.FirstOrDefault(u => u.Email == email || u.Username == username);
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException(nameof(GetUserByUsername));
        }

        public void CreateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
        }
    }
}