using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MoviesDbContext>(x => x.UseSqlServer(connectionString));
            services.AddTransient<IRepository<Movie>, MovieRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
          

            return services;
        }
    }
}
