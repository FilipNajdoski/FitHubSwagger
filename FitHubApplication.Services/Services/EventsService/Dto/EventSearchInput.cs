using System;
using FitHubApplication.Services.BaseDto;

namespace FitHubApplication.Services
{
    public class EventSearchInput : PagedResultRequestDto
    {
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}