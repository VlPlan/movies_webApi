using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModels;
using Models;

namespace Services
{
    public class MovieService:IMovieService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Movie> _movieRepository;

        public MovieService(IRepository<User> userRepository, IRepository<Movie> movieRepository)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public void AddMovie(MovieModel movie)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Id == movie.UserId);

            if (string.IsNullOrEmpty(movie.Title)) throw new Exception ("Field is required!");

            var newMovie = new Movie() { Title = movie.Title, Genre = (int)movie.Genre, Year = movie.Year, UserId = user.Id };

            _movieRepository.Add(newMovie);
        }

        public void DeleteMovie(int id, int userId)
        {
            var movie = _movieRepository.GetAll().FirstOrDefault(x => x.Id == id && x.UserId == userId);
            _movieRepository.Delete(movie); 
        }

        public MovieModel GetMovie(int id, int userId)
        {
            var movie = _movieRepository.GetAll().SingleOrDefault(x => x.Id == id && x.UserId == userId);
            var movieModel = new MovieModel() { Id = movie.Id, Title = movie.Title, Genre = (MovieGenre)movie.Genre, Year = movie.Year, UserId = movie.UserId };

            return movieModel;
        }

        public IEnumerable<MovieModel> GetUserMoviesList(int userId)
        {
            return _movieRepository.GetAll().Where(x => x.UserId == userId).Select(x => new MovieModel()
            {
                Id = x.Id,
                Title = x.Title,
                Genre = (MovieGenre)x.Genre,
                Year = x.Year,
                UserId = x.UserId
            });
        }
    }
}
