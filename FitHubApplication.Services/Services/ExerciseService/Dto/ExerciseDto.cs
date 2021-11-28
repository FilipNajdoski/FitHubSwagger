namespace FitHubApplication.Services
{
    public class ExerciseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Coeficient { get; set; }

        public int? ExerciseImageId { get; set; }
    }
}
