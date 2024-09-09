using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace MovieCardsAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(apperror =>
            {
                apperror.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    //context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    {
                        var problemDetails = new ProblemDetails
                        {
                            Status = context.Response.StatusCode,
                            Title = "Internal server Error",
                            Detail = contextFeature.Error.Message
                        };

                        await context.Response.WriteAsJsonAsync(problemDetails);
                    }
                });
            });
        }
    }
}
