using FitHubApplication.Models.AppEnums;
using System.Collections.Generic;

namespace FitHubApplication.Models.Entities
{
    public class Group
    {
        public int Id { get; set; }

        public string CoachId { get; set; }

        public User Coach { get; set; }

        public Enums.Level Level { get; set; }

        public ICollection<GroupTrainee> GroupTrainees { get; set; }
    }
}
