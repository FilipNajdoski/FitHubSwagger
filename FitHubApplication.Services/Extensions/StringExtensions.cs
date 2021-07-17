using System;
using System.IO;

namespace FitHubApplication.Services.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Converts a file path to a base64 string
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new directory if one with given path doesn`t exist 
        /// </summary>
        /// <param name="directoryPath"></param>
        public static void CreateDirectory(this string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>
        /// Creates a new file if one with given path doesn`t exist 
        /// </summary>
        /// <param name="filePath"></param>
        public static void CreateFile(this string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }
    }
}
