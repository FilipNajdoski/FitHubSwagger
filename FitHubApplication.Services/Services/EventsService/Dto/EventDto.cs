using System;

namespace FitHubApplication.Services
{
    public class EventDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int GroupId { get; set; }

        public GroupDto Group { get; set; }
    }
}
