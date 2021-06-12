using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkSenderAPI.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        if (contextFeature.Error.GetType() == typeof(ApplicationException))
                        {

                            await context.Response.WriteAsync(new ErrorDetails
                            {
                                Status = ResponseStatus.FatalError,
                                Message = contextFeature.Error.Message,
                            }.ToString());
                        }
                        else if (contextFeature.Error.GetType() == typeof(InvalidOperationException))
                        {

                            await context.Response.WriteAsync(new ErrorDetails
                            {
                                Status = ResponseStatus.AppError,
                                Message = contextFeature.Error.Message,
                            }.ToString());

                        }

                    }
                });
            });
        }
    }
}
