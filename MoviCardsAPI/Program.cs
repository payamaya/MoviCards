using Microsoft.EntityFrameworkCore;
using MoviCardsAPI.Data;
using MoviCardsAPI.Models.Entities;

namespace MoviCardsAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Register AppDbContext with the DI container
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MoviCardsContext")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Create a scope to resolve services
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();

                // Ensure the database is created
                context.Database.EnsureCreated();

                // Call the method to add sample data
                await AddSampleData(context);
            }

            app.Run();
        }

        // Sample data method
        public static async Task AddSampleData(AppDbContext context)
        {
            var contactInformation = new ContactInformation
            {
                Email = "director@example.com",
                PhoneNumber = 123456789
            };

            var director = new Director
            {
                Name = "John Doe",
                DateOfBirth = new DateTime(1975, 1, 1),
                ContactInformation = contactInformation
            };

            var actor1 = new Actor
            {
                Name = "Actor One",
                DateOfBirth = new DateTime(1985, 6, 15)
            };
          

            var genre1 = new Genre
            {
                Name = "Action"
            };

            var movie = new Movie
            {
                Title = "Sample Movie",
                Rating = 5,
                ReleaseDate = DateTime.UtcNow,
                Description = "A sample movie description.",
                Director = director,
                Actors = new List<Actor> { actor1 },
                Genres = new List<Genre> { genre1 }
            };

            context.Movies.Add(movie);
            await context.SaveChangesAsync();
        }
    }
}
