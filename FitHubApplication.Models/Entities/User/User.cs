using FitHubApplication.Models.AppEnums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FitHubApplication.Models.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public Enums.Gender Gender { get; set; }

        public Enums.Level Level { get; set; }

        public string Description { get; set; }

        public int? ProfilePictureId { get; set; }

        public UploadedFiles ProfilePicture { get; set; }

        public ICollection<UserExercise> UserExercises { get; set; }
    }
}
