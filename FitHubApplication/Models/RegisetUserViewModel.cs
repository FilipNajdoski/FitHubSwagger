using FitHubApplication.Services;

namespace FitHubApplication.Models
{
    public class RegisetUserViewModel
    {
        public CreateUserDto User { get; set; }
        public string PlainPassword { get; set; }
    }
}
