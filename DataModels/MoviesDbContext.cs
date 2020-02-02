using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataModels
{
    public class MoviesDbContext:DbContext
    {
        public MoviesDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }


        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Movie>().HasOne(x => x.User).WithMany(x => x.MoviesList).HasForeignKey(x => x.UserId);

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword1 = Encoding.ASCII.GetString(md5data);

            var md = new MD5CryptoServiceProvider();
            var mddata = md.ComputeHash(Encoding.ASCII.GetBytes("654321sedc"));
            var hashedPassword2 = Encoding.ASCII.GetString(mddata);

            model.Entity<User>().HasData(
                new User()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Bobsky",
                Username = "bob007",
                Password = hashedPassword1

            },
                new User()
            {
                Id = 2,
                FirstName = "Milan",
                LastName = "Vujovic",
                Username = "mil007",
                Password = hashedPassword2

            });
    
            model.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = 1,
                    Title = "Fast and Furious",
                    Genre = 4,
                    Year = 2010,
                    UserId = 2
                },
            new Movie()
            {
                Id = 2,
                Title = "Fast and Furious",
                Genre = 4,
                Year = 2010,
                UserId = 1
            },
            new Movie()
            {
                Id = 3,
                Title = "Scary Movie",
                Genre = 1,
                Year = 2008,
                UserId = 2,
            },
             new Movie()
             {
                 Id = 4,
                 Title = "Matrix",
                 Genre = 5,
                 Year = 2009,
                 UserId = 1
             });

        }
    }
}
