using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DataAccess
{
   public class UserRepository :IRepository<User>
    {
        private readonly MoviesDbContext _context;

        public UserRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Update(User updatedUser)
        {
            _context.Users.Update(updatedUser);
            _context.SaveChanges();
        }
    }
}
