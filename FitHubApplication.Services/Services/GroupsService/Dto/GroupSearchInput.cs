using FitHubApplication.Services.BaseDto;

namespace FitHubApplication.Services
{
    public class GroupSearchInput : PagedResultRequestDto
    {
        public string CoachName { get; set; }

        public string CoachSurname { get; set; }

        public string Level { get; set; }
    }
}
