using FitHubApplication.Logger;
using FitHubApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net;

namespace FitHubApplication.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        string path = $@"C:\FitHubLogs\";
                        string fileName = "Logs.txt";
                        string filePath = Path.Combine(path, fileName);

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);

                        }
                        if (!File.Exists(filePath))
                        {
                            File.Create(filePath);
                        }
                        LogWriter.WriteLog(contextFeature.Error, filePath);

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                        }.ToString());
                    }
                });
            });
        }
    }
}
