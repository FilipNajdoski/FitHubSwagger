using FitHubApplication.Models.Entities;
using FitHubApplication.Repositories;
using FitHubApplication.Services.Extensions;
using FitHubApplication.Services.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExcerciseRepository excerciseRepository;

        public ExerciseService(IExcerciseRepository excerciseRepository)
        {
            this.excerciseRepository = excerciseRepository;
        }

        public async Task<List<ExerciseDto>> Search(ExerciseSearchInput input)
        {
            IQueryable<Exercise> query = excerciseRepository.GetAll()
                .Include(x => x.UserExercises)
                    .ThenInclude(x => x.User)
                .Include(x => x.ExerciseImage)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Name), x => x.Name.Contains(input.Name))
                .WhereIf(!string.IsNullOrWhiteSpace(input.Description), x => x.Description.Contains(input.Description))
                .WhereIf(input.Coeficient.HasValue, x => x.Coeficient.Equals(input.Coeficient.Value));

            List<ExerciseDto> result = await query
                .Skip(input.SkipCount)
                .Take(input.TakeCount)
                .Select(x => x.EntityToDto())
                .ToListAsync();

            return result;
        }
         
        public async Task Create(CreateExerciseDto createExerciseDto) 
        {
            await excerciseRepository.Create(createExerciseDto.CreateDtoToEntity());
        }

        public async Task Update(ExerciseDto exercise)
        {
            await excerciseRepository.Update(exercise.DtoToEntity());
        }

        public async Task Delete(int id)
        {
            Exercise exercise = new Exercise
            {
                Id = id,
            };

            await excerciseRepository.Delete(exercise);
        }
    }
}
