using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IMovieService
    {
        IEnumerable<MovieModel> GetUserMoviesList(int userId);
        MovieModel GetMovie(int id, int userId);
        void AddMovie(MovieModel movie);
        void DeleteMovie(int id, int userId);
    }
}
