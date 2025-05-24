using System;
using Donouts.Middlewares;

namespace Donas.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorEventHandlerMiddleware>();
        }
    }
}

