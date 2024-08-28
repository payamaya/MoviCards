using Microsoft.EntityFrameworkCore;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<MovieCardsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MoviCardsContext")));

        builder.Services.AddControllers();
     /*   builder.Services.AddAutoMapper<MovieCardsContext>();*/

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
/*            await app.SeeDataAsync();*/
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<MovieCardsContext>();

            context.Database.EnsureCreated();

            // Uncomment and adjust if necessary
            // await AddSampleData(context);
        }

        app.Run();
    }

    // Uncomment and update this method to test data addition if needed
    /*
    public static async Task AddSampleData(MovieCardsContext context)
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

        context.ContactInformations.Add(contactInformation);
        context.Directors.Add(director);
        await context.SaveChangesAsync();

        // Add more data if needed
    }
    */
}
