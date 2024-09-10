using Domain.Contracts;
using MovieCardsAPI.Extensions;
using Movies.Infrastructure.Data;
using Movies.Infrastructure.Repository;
using Service;
using Movies.Presentation;


public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        /* Add services to the container*/
        builder.Services.ConfigureSql(builder.Configuration);
        builder.Services.AddControllers(configure => configure.ReturnHttpNotAcceptable=true)
            .AddNewtonsoftJson()
            .AddApplicationPart(typeof(AssemblyReference).Assembly);
        
        builder.Services.AddAutoMapper(typeof(MapperProfile));
        // From extensions folder 
        builder.Services.ConfigureCors();
        builder.Services.ConfigureOpenApi();
        /*     builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
             builder.Services.AddScoped<IServiceManager, ServiceManager>();*/
        builder.Services.ConfigureServices();
        builder.Services.ConfigureRepositories();

        var app = builder.Build();
        // Configure the HTTP request pipline
        app.ConfigureExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            await app.SeedDataAsync();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthorization();

        app.MapControllers();

    /*    using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<MovieCardsContext>();

            context.Database.EnsureCreated();

            // Uncomment and adjust if necessary
            // await AddSampleData(context);
        }*/

        app.Run();
    }


}
