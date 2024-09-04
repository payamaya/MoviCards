using Bogus;
using Microsoft.EntityFrameworkCore;

namespace MovieCardsAPI.Data
{
    public static class SeedData
    {
        public static async Task SeedDataAsync(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var servicesProvider = scope.ServiceProvider;
                var db = servicesProvider.GetRequiredService<MovieCardsContext>();

                await db.Database.MigrateAsync();

                if (await db.Movies.AnyAsync()) return;

                try
                {
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
                    await db.Movies.AddRangeAsync(movies);

                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    throw;
                }
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

        private static IEnumerable<Actor> GenerateActors(int count)
        {
            var faker = new Faker<Actor>("sv").Rules((f, a) =>
            {
                a.Name = f.Person.FullName;
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

        private static IEnumerable<Movie> GenerateMovies(int count, List<Director> directors, List<Actor> actors, List<Genre> genres)
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

            movies.AddRange(faker.Generate(count));

            return movies;
        }

        private static IEnumerable<MovieActor> GenerateMovieActors(List<Actor> actors, Guid movieId)
        {
            var faker = new Faker<MovieActor>("sv").Rules((f, ma) =>
            {
                ma.ActorId = f.PickRandom(actors).Id; // Assuming ActorId is Guid
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
  