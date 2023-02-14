using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Assignment.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {

        }

        public DbSet<ApplicationResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieId = 1,
                    Category = "Action",
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    Category = "Action",
                    Title = "Batman Begins",
                    Year = 2005,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false
                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    Category = "Action",
                    Title = "The Dark Knight Rises",
                    Year = 2012,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false
                }
                );
        }
    }
}
