using Education.Core;
using Education.Core.Services;
using Education.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Education.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var logService = scope.ServiceProvider.GetService<ILogService>();

            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;
                    // Log operation
                    await logService.AddLog(new Core.Models.Log() { LogLevel = LogLevel.Error, Message = $"StatusCode :: [{statusCode}] :: {exceptionFeature.Error.Message}" });

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
