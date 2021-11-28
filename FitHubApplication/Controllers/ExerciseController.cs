using FitHubApplication.Helpers;
using FitHubApplication.Models.Constants;
using FitHubApplication.Services;
using FitHubApplication.Services.Exceptions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitHubApplication.Controllers
{
    [Route(ApplicationConsts.ControllerConsts.DefaultControllerRoute)]
    [EnableCors(PolicyName = ApplicationConsts.CorsConsts.CorsPolicy)]
    [ApiController]
    [Authorize]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        /// <summary>
        /// Returns a list of exercises filtered by provided input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ExerciseDto>>> Search(ExerciseSearchInput input)
        {
            ExceptionHelper.NullCheck<ExerciseSearchInput>(input, ApplicationConsts.ExceptionMessages.SearchIsNull);

            List<ExerciseDto> exerciseDtos = await exerciseService.Search(input);

            return Ok(exerciseDtos);
        }

        /// <summary>
        /// Creates a new exercise
        /// </summary>
        /// <param name="createExerciseDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(CreateExerciseDto createExerciseDto)
        {
            ExceptionHelper.NullCheck<CreateExerciseDto>(createExerciseDto, ApplicationConsts.ExceptionMessages.InputIsNull);

            await exerciseService.Create(createExerciseDto);

            return Ok();
        }

        /// <summary>
        /// Updates an existing exercise
        /// </summary>
        /// <param name="exerciseDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update(ExerciseDto exerciseDto)
        {
            ExceptionHelper.NullCheck<ExerciseDto>(exerciseDto, ApplicationConsts.ExceptionMessages.InputIsNull);

            await exerciseService.Update(exerciseDto);

            return Ok();
        }

        /// <summary>
        /// Deletes an existing exercise
        /// </summary>
        /// <param name="exerciseId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(int exerciseId)
        {
            ExceptionHelper.NullCheck(exerciseId, ApplicationConsts.ExceptionMessages.InputIsNull);

            await exerciseService.Delete(exerciseId);

            return Ok();
        }
        
    }
}
