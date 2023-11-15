using Application.Abstractions.Auth;
using Application.Abstractions.Services;
using Application.Database;
using Application.Features.TrainingPlanExercises.Dto;
using Domain.Abstractions.Exceptions;
using Domain.TrainingPlans;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.TrainingPlanExercises;

public class TrainingPlanExerciseService : ITrainingPlanExerciseService
{
    private readonly TrainingDbContext _context;
    private readonly IUserContext _userContext;

    public TrainingPlanExerciseService(TrainingDbContext context, IUserContext userContext)
    {
        _context = context;
        _userContext = userContext;
    }

    public IEnumerable<TrainingPlanExerciseDto> GetAllExercises()
    {
        var exercise = _context.TrainingPlanExercises
            .AsSplitQuery()
            .Select(e => new TrainingPlanExerciseDto
            {
                Id = e.Id,
                Name = e.Name,
                MuscleGroup = e.MuscleGroup.ToString(),
                ImgUrl = e.ImgUrl
            })
            .ToList();

        return exercise;
    }

    public IEnumerable<TrainingPlanExerciseDetailsDto> GetUserAndGlobalTrainingPlanExercise()
    {
        var exercise = _context.TrainingPlanExercises
            .AsSplitQuery()
            .Where(e => e.CreatedBy == _userContext.UserId || e.IsGlobal)
            .Select(e => new TrainingPlanExerciseDetailsDto
            {
                Id = e.Id,
                Name = e.Name,
                MuscleGroup = e.MuscleGroup,
                Description = e.Description,
                ImgUrl = e.ImgUrl,
                TutorialUrl = e.TutorialUrl
            })
            .ToList();

        return exercise;
    }

    public TrainingPlanExerciseDetailsDto GetExerciseDetails(Guid id)
    {
        var exercise = _context.TrainingPlanExercises
            .Where(e => e.Id == id)
            .Select(e => new TrainingPlanExerciseDetailsDto
            {
                Id = e.Id,
                Name = e.Name,
                MuscleGroup = e.MuscleGroup,
                Description = e.Description,
                ImgUrl = e.ImgUrl,
                TutorialUrl = e.TutorialUrl
            })
            .FirstOrDefault();

        if (exercise is null)
            throw new EntityNotFoundException(typeof(TrainingPlanExercise), id);

        return exercise;
    }

    public Guid CreateExercise(CreateTrainingPlanExerciseDto dto)
    {
        var isGlobal = _userContext.Role == Role.Admin;
        var exercise = TrainingPlanExercise.Create(
            dto.Name,
            isGlobal,
            dto.MuscleGroup,
            dto.Description,
            dto.ImgUrl,
            dto.TutorialUrl
        );

        _context.TrainingPlanExercises.Add(exercise);
        _context.SaveChanges();

        return exercise.Id;
    }

    public void DeleteExercise(Guid id)
    {
        var exercise = _context.TrainingPlanExercises
            .FirstOrDefault(e => e.Id == id);

        if (exercise is null)
            throw new EntityNotFoundException(typeof(TrainingPlanExercise), id);

        _context.Remove(exercise);
        _context.SaveChanges();
    }

    public Guid UpdateExercise(Guid id, CreateTrainingPlanExerciseDto dto)
    {
        var exercise = _context.TrainingPlanExercises
            .FirstOrDefault(e => e.Id == id);

        if (exercise is null)
            throw new EntityNotFoundException(typeof(TrainingPlanExercise), id);

        exercise.Update(
            dto.Name,
            dto.MuscleGroup,
            dto.Description,
            dto.ImgUrl,
            dto.TutorialUrl
        );
        _context.SaveChanges();

        return exercise.Id;
    }
}