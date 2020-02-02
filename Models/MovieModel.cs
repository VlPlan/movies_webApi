using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public MovieGenre Genre { get; set; }
        public int UserId { get; set; }

    }

    public enum MovieGenre
    {
        Comedy = 1,
        Thriller = 2,
        Horror = 3,
        Action = 4,
        SciFi = 5,
        Drama = 6
    }
}
