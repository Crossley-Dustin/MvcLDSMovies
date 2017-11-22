using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "Meet the Mormons",
                         ReleaseDate = DateTime.Parse("2014-10-10"),
                         Genre = "Documentary",
                         Rating = "PG",
                         Price = 4.98M
                     },

                     new Movie
                     {
                         Title = "17 Miracles",
                         ReleaseDate = DateTime.Parse("2011-6-3"),
                         Genre = "Adventure",
                         Rating = "PG",
                         Price = 11.99M
                     },

                     new Movie
                     {
                         Title = "Singles Ward",
                         ReleaseDate = DateTime.Parse("2002-1-30"),
                         Genre = "Comedy",
                         Rating = "PG",
                         Price = 19.99M
                     },

                   new Movie
                   {
                       Title = "The Other Side of Heaven",
                       ReleaseDate = DateTime.Parse("2002-4-12"),
                       Genre = "Adventure",
                       Rating="PG",
                       Price = 12.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}