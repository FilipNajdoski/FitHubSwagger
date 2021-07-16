using System.ComponentModel.DataAnnotations;

namespace FitHubApplication.Models.AppEnums
{
    public class Enums
    {
        public enum Gender
        {
            [Display(Name = "Male")]
            Male,

            [Display(Name = "Female")]
            Female,

            [Display(Name = "Other")]
            Other
        }

        public enum Level
        {
            [Display(Name = "Beginner")]
            Beginner,

            [Display(Name = "Intermediate")]
            Intermediate,

            [Display(Name = "Advanced")]
            Advanced,
        }
    }
}
