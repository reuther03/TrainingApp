using Api.Controllers.Base;
using Application.Abstractions.Services;
using Application.Features.TrainingPlanExercises.Dto;
using Application.Features.TrainingPlans.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class TrainingPlansController : BaseController
{
    private readonly ITrainingPlanService _trainingPlanService;

    public TrainingPlansController(ITrainingPlanService trainingPlanService)
    {
        _trainingPlanService = trainingPlanService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _trainingPlanService.GetAllPlans();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetDetails([FromRoute] Guid id)
    {
        var result = _trainingPlanService.GetTrainingPlanDetails(id);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateTrainingPlanDto dto)
    {
        var result = _trainingPlanService.CreateTrainingPlan(dto);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTrainingPlan([FromRoute] Guid id)
    {
        _trainingPlanService.DeleteTrainingPlan(id);
        return NoContent();
    }

    [HttpPut("{id:guid}/add-new-exercise")]
    public IActionResult AddNewExercise([FromRoute] Guid id, CreateTrainingPlanExerciseDto dto)
    {
        _trainingPlanService.AddNewTrainingPlanExercise(id, dto);
        return Ok();
    }

    [HttpPut("{id:guid}/add-exercise/{exerciseId:guid}")]
    public IActionResult AddExistingExercise([FromRoute] Guid id, [FromRoute] Guid exerciseId)
    {
        _trainingPlanService.AddExistingTrainingPlanExercise(id, exerciseId);
        return Ok();
    }

    [HttpDelete("{id:guid}/exercises/{exerciseId:guid}")]
    public IActionResult DeleteTrainingPlanExercise([FromRoute] Guid id, [FromRoute] Guid exerciseId)
    {
        _trainingPlanService.DeleteTrainingPlanExercise(id, exerciseId);
        return NoContent();
    }

}