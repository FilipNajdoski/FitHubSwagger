using FitHubApplication.Models.AppEnums;
using FitHubApplication.Models.Entities;
using FitHubApplication.Services.Extensions;
using System.Linq;

namespace FitHubApplication.Services.Mapper
{
    public static class GroupMapper
    {
        /// <summary>
        /// Converts <see cref="Group"/> to <see cref="GroupDto"/>
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public static GroupDto EntityToDto(this Group group)
        {
            return new GroupDto
            {
                Id = group.Id,
                Coach = group.Coach.EntityToDto(),
                CoachId = group.CoachId,
                Level = group.Level.GetDisplayName(),
                GroupTrainees = group.GroupTrainees.Select(x => x.Trainee.EntityToDto()).ToList(),
            };
        }

        /// <summary>
        /// Converts <see cref="GroupDto"/> to <see cref="Group"/>
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public static Group DtoToEntity(this GroupDto group)
        {
            return new Group
            {
                Id = group.Id,
                Coach = group.Coach.DtoToEntity(),
                CoachId = group.CoachId,
                Level = group.Level.ToEnum<Enums.Level>(),
            };
        }

        /// <summary>
        /// Converts <see cref="CreateGroupDto"/> to <see cref="Group"/>
        /// </summary>
        /// <param name="createGroupDto"></param>
        /// <returns></returns>
        public static Group CreateDtoToEntity(this CreateGroupDto createGroupDto)
        {
            return new Group
            {
                CoachId = createGroupDto.CoachId,
                Level = createGroupDto.Level.ToEnum<Enums.Level>(),
            };
        }
    }
}
