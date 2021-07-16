using System;

namespace FitHubApplication.Models.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
