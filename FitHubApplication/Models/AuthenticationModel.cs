using System;

namespace FitHubApplication.Models
{
    public class AuthenticationModel
    {
        public string AccessToken { get; set; }

        public string EncryptedAccessToken { get; set; }

        public DateTime ExpirationTime { get; set; }
    }
}
