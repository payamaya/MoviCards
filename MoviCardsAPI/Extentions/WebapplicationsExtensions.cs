/*using Microsoft.EntityFrameworkCore;
*//*using MovieCardsAPI.Data;*//*

namespace MovieCardsAPI.Extentions
{
    public static class WebapplicationsExtensions
    {
        public static async Task SeeDataAsync(this  IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<MovieCardsContext>();

                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();

                try
                {
                    await SeedData.InitAsync(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                }
            }

        }
    }
}
*/