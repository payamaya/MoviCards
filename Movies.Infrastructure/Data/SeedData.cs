using Bogus;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Movies.Infrastructure.Data
{
    public static class SeedData
    {
        private static UserManager<ApplicationUser> userManager = null!;
        private static RoleManager<IdentityRole> roleManager = null!;
        private static IConfiguration configuration = null!;
        private const string actorRole = "Actor";
        private const string adminRole = "Admin";

        public static async Task SeedDataAsync(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var servicesProvider = scope.ServiceProvider;
                var db = servicesProvider.GetRequiredService<MovieCardsContext>();
                if (await db.Movies.AnyAsync()) return;

                userManager = servicesProvider.GetRequiredService<UserManager<ApplicationUser>>();
                roleManager = servicesProvider.GetRequiredService<RoleManager<IdentityRole>>();
                configuration = servicesProvider.GetRequiredService<IConfiguration>();

                try
                {
                    await CreateRolesAsync(new[] { adminRole, actorRole });

                    // Seed Directors first
                    var directors = GenerateDirectors(10).ToList();
                    await db.Directors.AddRangeAsync(directors);

                    // Seed Actors
                    var actors = GenerateActors(10).ToList();
                    await db.Actors.AddRangeAsync(actors);

                    // Seed Genres
                    var genres = GenerateGenres(5).ToList();
                    await db.Genres.AddRangeAsync(genres);

                    await db.SaveChangesAsync();

                    // Seed Movies
                    var movies = GenerateMovies(4, directors, actors, genres);
                    await db.Movies.AddRangeAsync((IEnumerable<Movie>)movies);

                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    throw;
                }
            }
        }

        private static async Task CreateRolesAsync(string[] roleNames)
        {
            foreach (var roleName in roleNames)
            {
                if (await roleManager.RoleExistsAsync(roleName)) continue;
                var role = new IdentityRole { Name = roleName };
                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }

        private static IEnumerable<Director> GenerateDirectors(int count)
        {
            var faker = new Faker<Director>("sv").Rules((f, d) =>
            {
                d.Name = f.Person.FullName;
                d.DateOfBirth = f.Date.Past(50, DateTime.Now.AddYears(-30));
            });

            return faker.Generate(count);
        }

        private static IEnumerable<ApplicationUser> GenerateActors(int count)
        {
            var faker = new Faker<ApplicationUser>("sv").Rules((f, a) =>
            {
                a.Name = f.Person.FullName;
                a.ContactInformation = new ContactInformation
                {
                    PhoneNumber = f.Phone.PhoneNumber(),
                    Email = f.Internet.Email()
                };
                a.ContactInformationId = a.ContactInformation.Id; // Set ContactInformationId
            });

            return faker.Generate(count);
        }

        private static IEnumerable<Genre> GenerateGenres(int count)
        {
            var faker = new Faker<Genre>("sv").Rules((f, g) =>
            {
                g.Name = f.Commerce.Categories(1)[0];
            });

            return faker.Generate(count);
        }

        private static async Task GenerateMovies(int count, List<Director> directors, List<ApplicationUser> actors, List<Genre> genres)
        {
            var movies = new List<Movie>();
            var faker = new Faker<Movie>("sv").Rules((f, m) =>
            {
                m.Title = f.Lorem.Sentence(3);
                m.Rating = f.Random.Int(1, 5);
                m.ReleaseDate = f.Date.Past(20);
                m.Description = f.Lorem.Paragraph();
                m.DirectorId = f.PickRandom(directors).Id; // Assuming DirectorId is Guid
                m.MovieActors = GenerateMovieActors(actors, m.Id).ToList();
                m.MovieGenres = GenerateMovieGenres(genres, m.Id).ToList();
            });

            var moviesList = faker.Generate(count);

            // Generate user roles
            var passWord = configuration["password"];
            if (string.IsNullOrEmpty(passWord))
                throw new Exception("password not exist in config");

            foreach (var actor in actors)
            {
                var result = await userManager.CreateAsync(actor, passWord);
                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

                // Assign role based on some condition or directly set to "Actor"
                await userManager.AddToRoleAsync(actor, actorRole);
            }

            foreach (var movie in moviesList)
            {
                // Add movie to the list
                movies.Add(movie);
            }
        }

        private static IEnumerable<MovieActor> GenerateMovieActors(List<ApplicationUser> actors, Guid movieId)
        {
            var faker = new Faker<MovieActor>("sv").Rules((f, ma) =>
            {
                ma.ActorId = f.PickRandom(actors).Id; // ActorId is now a string
                ma.MovieId = movieId; // Set correct MovieId
            });

            return faker.Generate(2); // Generate 2 actors per movie
        }

        private static IEnumerable<MovieGenre> GenerateMovieGenres(List<Genre> genres, Guid movieId)
        {
            var faker = new Faker<MovieGenre>("sv").Rules((f, mg) =>
            {
                mg.GenreId = f.PickRandom(genres).Id; // Assuming GenreId is Guid
                mg.MovieId = movieId; // Set correct MovieId
            });

            return faker.Generate(1); // Generate 1 genre per movie
        }
    }
}
