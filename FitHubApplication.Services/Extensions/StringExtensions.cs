using System;
using System.IO;

namespace FitHubApplication.Services.Extensions
{
    public static class StringExtensions
    {
        public static string ToBase64(this string filePath)
        {
            if(!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                using MemoryStream memoryStream = new MemoryStream();

                using FileStream fileStream = new FileStream(filePath, FileMode.Open);

                fileStream.CopyTo(memoryStream);

                return Convert.ToBase64String(memoryStream.ToArray());
            }

            return string.Empty;
        }
    }
}
