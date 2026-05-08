using Microsoft.AspNetCore.Diagnostics;
using Application.Common.Exceptions;

namespace API.Middleware
{
    public static class ExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                    if (exception is UnauthorizedException)
                    {
                        context.Response.StatusCode = 401;

                        await context.Response.WriteAsJsonAsync(new
                        {
                            message = exception.Message
                        });

                        return;
                    }
                    else
                    {
                        context.Response.StatusCode = 500;

                        await context.Response.WriteAsJsonAsync(new
                        {
                            message = "Server error"
                        });

                        return;
                    }

            
                });
            });

            return app;
        }
    }
}