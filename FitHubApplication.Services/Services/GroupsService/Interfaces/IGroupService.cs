using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public interface IGroupService
    {
        Task<List<GroupDto>> Search(GroupSearchInput input);

        Task Create(CreateGroupDto createGroupDto);

        Task Delete(int groupId);

        Task<GroupDto> Update(GroupDto groupDto);
    }
}
