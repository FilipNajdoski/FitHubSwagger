namespace FitHubApplication.Models.Entities
{
    public class GroupTrainee
    {
        public int Id { get; set; }

        public string TraineeId { get; set; }

        public User Trainee { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
