using FitHubApplication.Services.BaseDto;

namespace FitHubApplication.Services
{
    public class ExerciseSearchInput : PagedResultRequestDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Coeficient { get; set; }
    }
}
