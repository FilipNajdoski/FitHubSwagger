using FitHubApplication.Models.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitHubApplication.Models.Entities
{
    public class UserExercise
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        [Column(TypeName = ApplicationConsts.ConfigConsts.SqlDecimalType)]
        public decimal PersonalRecord { get; set; }
    }
}
