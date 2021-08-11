using System.Collections.Generic;

namespace FitHubApplication.Services
{
    public class GroupDto
    {
        public int Id { get; set; }

        public string CoachId { get; set; }

        public UserDto Coach { get; set; }

        public string Level { get; set; }

        public List<UserDto> GroupTrainees { get; set; }
    }
}