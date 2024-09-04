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
    }
}
