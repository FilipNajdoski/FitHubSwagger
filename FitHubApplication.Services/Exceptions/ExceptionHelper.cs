using System;

namespace FitHubApplication.Services.Exceptions
{
    public static class ExceptionHelper
    {
        /// <summary>
        /// If <see cref="T"/> in null throws exception
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static void NullCheck<T>(T type, string message)
        {
            if(type is null)
            {
                throw new Exception(message);
            }
        }

        /// <summary>
        /// If condition is false throws an exception
        /// </summary>
        /// <param name="succeeded"></param>
        /// <param name="message"></param>
        public static void LoginFailed(bool succeeded, string message)
        {
            if (!succeeded)
            {
                throw new Exception(message);
            }
        }

        /// <summary>
        /// If string is empty thors an exception
        /// </summary>
        /// <param name="str"></param>
        /// <param name="message"></param>
        public static void StringIsEmpty(string str, string message)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                throw new Exception(message);
            }
        }
    }
}
