using FitHubApplication.Models.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitHubApplication.Models.Entities
{
    public class Exercise 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = ApplicationConsts.ConfigConsts.SqlDecimalType)]
        public decimal Coeficient  { get; set; }

        public int? ExerciseImageId { get; set; }

        public UploadedFiles ExerciseImage { get; set; }

        public ICollection<UserExercise> UserExercises { get; set; }
    }
}