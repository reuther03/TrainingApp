using Api.Controllers.Base;
using Application.Abstractions.Services;
using Application.Features.TrainingPlans.Dto;
using Application.Features.Trainings.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class TrainingsController : BaseController
{
    private readonly ITrainingService _trainingService;

    public TrainingsController(ITrainingService trainingService)
    {
        _trainingService = trainingService;
    }

    [HttpPost("{trainingPlanId:guid}/start")]
    [Authorize]
    public IActionResult Start([FromRoute] Guid trainingPlanId)
    {
        var result = _trainingService.StartTraining(trainingPlanId);
        return Ok(result);
    }

    [HttpPut("{trainingId:guid}/exercises/{exerciseId:guid}")]
    [Authorize]
    public IActionResult SetExerciseDetails([FromRoute] Guid trainingId, [FromRoute] Guid exerciseId, [FromBody] ExerciseDetailsDto dto)
    {
        _trainingService.SetExerciseDetails(trainingId, exerciseId, dto);
        return Ok();
    }

    // TODO: Endpoiny zwiazane z treningiem
}