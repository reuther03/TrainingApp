using System.Net;
using Api.Controllers.Base;
using Application.Abstractions.Services;
using Application.Dto.TrainingPlan;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class TrainingPlanExerciseController : BaseController
{
    private readonly ITrainingPlanExerciseService _trainingPlanExerciseService;

    public TrainingPlanExerciseController(ITrainingPlanExerciseService trainingPlanExerciseService)
    {
        _trainingPlanExerciseService = trainingPlanExerciseService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _trainingPlanExerciseService.GetAllExercises();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetDetails([FromRoute] Guid id)
    {
        var result = _trainingPlanExerciseService.GetExerciseDetails(id);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateTrainingPlanExerciseDto dto)
    {
        var result = _trainingPlanExerciseService.CreateExercise(dto);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteTrainingPlanExercise([FromRoute] Guid id)
    {
        _trainingPlanExerciseService.DeleteExercise(id);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateTrainingPlanExercise([FromRoute] Guid id, [FromBody] CreateTrainingPlanExerciseDto dto)
    {
        var result = _trainingPlanExerciseService.UpdateExercise(id, dto);
        return Ok(result);
    }
}