using Domain.Contracts;
using Movies.Infrastructure.Data;
using Movies.Infrastructure.Repository;
using Service;
using Service.Contracts;

namespace MovieCardsAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(builder =>
             {
                 builder.AddPolicy("AllowAll", p =>
                 p.AllowAnyOrigin()
                 .AllowAnyMethod().
                  AllowAnyHeader());
            });

        }

        public static void ConfigureSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieCardsContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("MoviCardsContext") ?? throw new InvalidOperationException("Connection string 'DBContext' not found.")));

        }
        public static void ConfigureOpenApi(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer().AddSwaggerGen();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IMovieService,MovieService>();
            services.AddScoped<IActorService,ActorService>();
            
            services.AddScoped(provider => new Lazy<IMovieService>(()=> provider.GetRequiredService<IMovieService>()));
            services.AddScoped(provider => new Lazy<IActorService>(()=> provider.GetRequiredService<IActorService>()));
        }  
        
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            
            services.AddScoped(provider => new Lazy<IMovieRepository>(()=> provider.GetRequiredService<IMovieRepository>()));
            services.AddScoped(provider => new Lazy<IActorRepository>(()=> provider.GetRequiredService<IActorRepository>()));
        }
    }
}
