using FitHubApplication.Models.Entities;

namespace FitHubApplication.Services.Mapper
{
    public static class ExerciseMapper
    {
        /// <summary>
        /// Converts from <see cref="Exercise"/> to <see cref="ExerciseDto"/>
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns></returns>
        public static ExerciseDto EntityToDto(this Exercise exercise)
        {
            return new ExerciseDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                Coeficient = exercise.Coeficient,
                ExerciseImageId = exercise.ExerciseImageId,
            };
        }

        /// <summary>
        /// Converts from <see cref="ExerciseDto"/> to <see cref="Exercise"/>
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns></returns>
        public static Exercise DtoToEntity(this ExerciseDto exercise)
        {
            return new Exercise
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                Coeficient = exercise.Coeficient,
                ExerciseImageId = exercise.ExerciseImageId,
            };
        }

        /// <summary>
        /// Converts from <see cref="CreateExerciseDto"/> to <see cref="Exercise"/>
        /// </summary>
        /// <param name="createExerciseDto"></param>
        /// <returns></returns>
        public static Exercise CreateDtoToEntity(this CreateExerciseDto createExerciseDto)
        {
            return new Exercise
            {
                Coeficient = createExerciseDto.Coeficient,
                Name = createExerciseDto.Name,
                Description = createExerciseDto.Description,
                ExerciseImageId = createExerciseDto.ExerciseImageId,
            };
        }
    }
}
