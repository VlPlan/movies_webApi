using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }

    public enum Genre
    {
        Comedy=1,
        Thriller=2,
        Horror=3,
        Action=4,
        SciFi=5,
        Drama=6
    }
}
