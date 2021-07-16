using System;

namespace FitHubApplication.Services.Exceptions
{
    public static class ExceptionHelper
    {
        public static void NullCheck<T>(T type, string message)
        {
            if(type is null)
            {
                throw new Exception(message);
            }
        }

        public static void LoginFailed(bool succeeded, string message)
        {
            if (!succeeded)
            {
                throw new Exception(message);
            }
        }

        public static void StringIsEmpty(string str, string message)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                throw new Exception(message);
            }
        }
    }
}
