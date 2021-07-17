using FitHubApplication.Services.BaseDto;
using System;

namespace FitHubApplication.Services
{
    public class UserSearchInput : PagedResultRequestDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public string Gender { get; set; }

        public string Level { get; set; }
    }
}
