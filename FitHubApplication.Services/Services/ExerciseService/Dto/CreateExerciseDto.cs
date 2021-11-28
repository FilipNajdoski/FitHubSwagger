namespace FitHubApplication.Services
{
    public class CreateExerciseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Coeficient { get; set; }

        public int? ExerciseImageId { get; set; }
    }
}
