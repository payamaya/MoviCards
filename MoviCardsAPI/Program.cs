using Microsoft.EntityFrameworkCore;
using MovieCardsAPI.Data;
using MovieCardsAPI.Models.Entities;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<MovieCardsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MoviCardsContext")));

        builder.Services.AddControllers();
     /*   builder.Services.AddAutoMapper<MovieCardsContext>();*/
 /*    builder.Services.AddAutoMapper<MovieCardsContext>();*/;
        builder.Services.AddAutoMapper(typeof(MapperProfile));

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


}
