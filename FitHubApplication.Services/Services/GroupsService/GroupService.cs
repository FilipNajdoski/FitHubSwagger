using FitHubApplication.Models.AppEnums;
using FitHubApplication.Models.Constants;
using FitHubApplication.Models.Entities;
using FitHubApplication.Repositories;
using FitHubApplication.Services.Exceptions;
using FitHubApplication.Services.Extensions;
using FitHubApplication.Services.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepository;
        private readonly IGroupTraineeRepository groupTraineeRepository;

        public GroupService(IGroupRepository groupRepository, IGroupTraineeRepository groupTraineeRepository)
        {
            this.groupRepository = groupRepository;
            this.groupTraineeRepository = groupTraineeRepository;
        }

        public async Task<List<GroupDto>> Search(GroupSearchInput input)
        {
            IQueryable<Group> query = groupRepository.GetAll()
                .Include(x => x.GroupTrainees)
                .Include(x => x.Coach)
                .WhereIf(!string.IsNullOrWhiteSpace(input.CoachName), x => x.Coach.Name.Contains(input.CoachName))
                .WhereIf(!string.IsNullOrWhiteSpace(input.CoachSurname), x => x.Coach.Surname.Contains(input.CoachSurname))
                .WhereIf(!string.IsNullOrWhiteSpace(input.Level), x => x.Level.Equals(input.Level.ToEnum<Enums.Level>()));

            List<GroupDto> result = await query
                .Skip(input.SkipCount)
                .Take(input.TakeCount)
                .Select(x => x.EntityToDto())
                .ToListAsync();

            return result;
        }

        public async Task Create(CreateGroupDto createGroupDto)
        {
            Group group = await groupRepository.Create(createGroupDto.CreateDtoToEntity());

            List<GroupTrainee> groupTrainees = new List<GroupTrainee>();

            createGroupDto.GroupTrainees.ForEach(x =>
            {
                CreateNewGroupTraineeAndAddItToList(group, x, groupTrainees);
            });

            await groupTraineeRepository.CreateMultiple(groupTrainees);
        }

        public async Task<GroupDto> Update(GroupDto groupDto)
        {
            Group group = await groupRepository.GetAll()
                .Include(x => x.GroupTrainees)
                .FirstOrDefaultAsync(x => x.Id.Equals(groupDto.Id));

            ExceptionHelper.NullCheck<Group>(group, ApplicationConsts.ExceptionMessages.GroupIsNull);

            group.Id = groupDto.Id;
            group.Level = groupDto.Level.ToEnum<Enums.Level>();

            await HandleDeleteTrainees(groupDto, group);

            await HandleCreateTrainees(groupDto, group);

            await groupRepository.Update(group);

            return group.EntityToDto();
        }

        public async Task Delete(int groupId)
        {
            Group group = new Group()
            {
                Id = groupId,
            };

            await groupRepository.Delete(group);
        }

        private async Task HandleCreateTrainees(GroupDto groupDto, Group group)
        {
            List<GroupTrainee> groupTrainees = new List<GroupTrainee>();

            List<UserDto> users = groupDto.GroupTrainees.Where(x => !group.GroupTrainees.Select(z => z.TraineeId).Contains(x.Id)).ToList();

            users.ForEach(x =>
            {
                CreateNewGroupTraineeAndAddItToList(group, x, groupTrainees);
            });

            await groupTraineeRepository.CreateMultiple(groupTrainees);
        }

        private async Task HandleDeleteTrainees(GroupDto groupDto, Group group)
        {
            List<GroupTrainee> groupTrainees = new List<GroupTrainee>();

            group.GroupTrainees.ToList().ForEach(x =>
            {
                UserDto userDto = groupDto.GroupTrainees.FirstOrDefault(z => z.Id.Equals(x.TraineeId));

                if (userDto is null)
                {
                    groupTrainees.Add(x);
                }
            });

            await groupTraineeRepository.DeleteMultiple(groupTrainees);
        }

        private static void CreateNewGroupTraineeAndAddItToList(Group group, UserDto x, List<GroupTrainee> groupTrainees)
        {
            GroupTrainee groupTrainee = new GroupTrainee
            {
                GroupId = group.Id,
                TraineeId = x.Id,
            };

            groupTrainees.Add(groupTrainee);
        }
    }
}