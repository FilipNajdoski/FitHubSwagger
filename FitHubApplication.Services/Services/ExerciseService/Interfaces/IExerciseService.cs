using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public interface IExerciseService
    {
        Task<List<ExerciseDto>> Search(ExerciseSearchInput input);

        Task Create(CreateExerciseDto createExerciseDto);

        Task Update(ExerciseDto exercise);

        Task Delete(int id);
    }
}
