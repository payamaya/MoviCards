/*using Bogus;
using Microsoft.EntityFrameworkCore;
using MovieCardsAPI.Controllers;
using MovieCardsAPI.Models.Entities;

namespace MovieCardsAPI.Data
{
    internal class SeedData
    {
        private static Faker faker = new Faker("sv");
        internal static async Task InitAsync(MovieCardsContext context)
        {
            // If Data exists dont run again!!
            if (await context.Movies.AnyAsync()) return;

            var movies = GenreteMovies(100);
           
        }

        private static object GenreteMovies(int numberOfMovies)
        {
            var movies = new List<Movie>(numberOfMovies);

            for (int i = 0; i < numberOfMovies; i++)
            {
               
            }
        }
    }
}*/