using Api.Controllers.Base;
using Application.Abstractions.Services;
using Application.Features.TrainingPlanExercises.Dto;
using Application.Features.TrainingPlans.Dto;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public IActionResult GetAll()
    {
        var result = _trainingPlanService.GetAllPlans();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public IActionResult GetDetails([FromRoute] Guid id)
    {
        var result = _trainingPlanService.GetTrainingPlanDetails(id);
        return Ok(result);
    }

    [HttpGet("user-training-plans")]
    [Authorize]
    [AuthorizeRoles(Role.Admin)]
    public IActionResult GetUsersTrainingPlans()
    {
        var result = _trainingPlanService.GetUserAndGlobalTrainingPlans();
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create([FromBody] CreateTrainingPlanDto dto)
    {
        var result = _trainingPlanService.CreateTrainingPlan(dto);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public IActionResult DeleteTrainingPlan([FromRoute] Guid id)
    {
        _trainingPlanService.DeleteTrainingPlan(id);
        return NoContent();
    }

    [HttpPut("{id:guid}/add-new-exercise")]
    [Authorize]
    public IActionResult AddNewExercise([FromRoute] Guid id, CreateTrainingPlanExerciseDto dto)
    {
        _trainingPlanService.AddNewTrainingPlanExercise(id, dto);
        return Ok();
    }

    [HttpPut("{id:guid}/add-exercise/{exerciseId:guid}")]
    [Authorize]
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