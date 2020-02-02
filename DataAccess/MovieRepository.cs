using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DataAccess
{
    public class MovieRepository:IRepository<Movie>
    {
        private readonly MoviesDbContext _context;

        public MovieRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public void Add(Movie entity)
        {
            _context.Movies.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            _context.Movies.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies;
        }

        public void Update(Movie update)
        {
            _context.Movies.Update(update);
            _context.SaveChanges();
        }
    }
}
