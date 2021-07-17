using FitHubApplication.Logger;
using FitHubApplication.Models;
using FitHubApplication.Models.Constants;
using FitHubApplication.Services.Extensions;
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

                    context.Response.ContentType = ApplicationConsts.MimeTypeConsts.ApplicationJson;

                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (!(contextFeature is null))
                    {
                        string path = ApplicationConsts.LogConsts.FithubLogsPath;

                        string fileName = ApplicationConsts.LogConsts.LogsFile;

                        string filePath = Path.Combine(path, fileName);

                        path.CreateDirectory();

                        filePath.CreateFile();

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
