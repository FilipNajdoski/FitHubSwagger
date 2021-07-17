using System.ComponentModel.DataAnnotations;

namespace FitHubApplication.Models.AppEnums
{
    public class Enums
    {
        public enum Gender
        {
            [Display(Name = "Other")]
            Other,

            [Display(Name = "Male")]
            Male,

            [Display(Name = "Female")]
            Female,
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
