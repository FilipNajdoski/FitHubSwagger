using System;

namespace FitHubApplication.Services
{
    public class CreateEventDto
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int GroupId { get; set; }
    }
}
