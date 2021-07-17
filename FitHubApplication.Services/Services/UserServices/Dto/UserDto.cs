using System;

namespace FitHubApplication.Services
{
    public class UserDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Gender { get; set; }

        public string Level { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public string Description { get; set; }

        public string ProfilePictureBase { get; set; }
    }
}
