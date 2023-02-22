using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Assignment.Models
{
    // defines class MovieContext as an extension of DbContext
    public class MovieContext : DbContext
    {
        // constructor for MovieContext class
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {

        }

        // define a DbSet that will hold instances of movies and categories
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        // overrides OnModelCreating default method, seeds database with given data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Action"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Horror"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Comedy"
                }
                );
            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false
                },
                new Movie
                {
                    MovieId = 2,
                    CategoryId = 1,
                    Title = "Batman Begins",
                    Year = 2005,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false
                },
                new Movie
                {
                    MovieId = 3,
                    CategoryId = 1,
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
