using Domain.Contracts;
using MovieCardsAPI.Extensions;
using Movies.Infrastructure.Data;
using Movies.Infrastructure.Repository;
using Service;
using Movies.Presentation;
using Microsoft.AspNetCore.Identity;


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

        builder.Services.AddAuthentication();
        builder.Services.AddIdentityCore<ApplicationUser>(opt =>
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 3;
            //opt.User.RequireUniqueEmail = false;
        }).AddRoles<IdentityRole>()
          .AddEntityFrameworkStores<MovieCardsContext>()
          .AddDefaultTokenProviders();    

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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }


}
