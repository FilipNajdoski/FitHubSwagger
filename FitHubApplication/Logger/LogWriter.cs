using FitHubApplication.Models.Constants;
using System;
using System.IO;

namespace FitHubApplication.Logger
{
    public class LogWriter
    {
        /// <summary>
        /// Writes <see cref="Exception"/> in specified file path
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="filePath"></param>
        internal static void WriteLog(Exception ex, string filePath)
        {
            using StreamWriter writer = new StreamWriter(filePath, true);
            writer.WriteLine(ApplicationConsts.LogConsts.Dashes);
            writer.WriteLine(ApplicationConsts.LogConsts.Date + DateTime.Now.ToString());
            writer.WriteLine();

            while (!(ex is null))
            {
                writer.WriteLine(ex.GetType().FullName);
                writer.WriteLine(ApplicationConsts.LogConsts.Message + ex.Message);
                writer.WriteLine(ApplicationConsts.LogConsts.Stacktrace + ex.StackTrace);

                ex = ex.InnerException;
            }
        }
    }
}
