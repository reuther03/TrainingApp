using Application.Abstractions.Auth;
using Application.Abstractions.Services;
using Application.Database;
using Application.Features.Trainings.Dto;
using Domain.Abstractions.Exceptions;
using Domain.TrainingPlans;
using Domain.Trainings;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Trainings;

public class TrainingService : ITrainingService
{
    private readonly TrainingDbContext _context;
    private readonly IUserContext _userContext;

    public TrainingService(TrainingDbContext context, IUserContext userContext)
    {
        _context = context;
        _userContext = userContext;
    }

    public Guid StartTraining(Guid trainingPlanId)
    {
        var trainingPlan = _context.TrainingPlans
            .Include(tp => tp.Exercises)
            .FirstOrDefault(tp => tp.Id == trainingPlanId);

        if (trainingPlan is null)
            throw new EntityNotFoundException(typeof(TrainingPlan), trainingPlanId);

        var trainingId = Guid.NewGuid();
        var trainingExercises = trainingPlan.Exercises.ToList()
            .Select(e => Exercise.Create(
                e.Name,
                e.MuscleGroup,
                e.Description,
                e.ImgUrl,
                e.TutorialUrl,
                trainingId))
            .ToList();

        var training = Training.Create(
            trainingId,
            trainingPlan.Name,
            trainingExercises,
            _userContext.UserId ?? Guid.Empty);

        _context.Trainings.Add(training);
        _context.SaveChanges();

        return training.Id;
    }

    public void SetExerciseDetails(Guid trainingId, Guid exerciseId, ExerciseDetailsDto dto)
    {
        var training = _context.Trainings
            .Include(t => t.Exercises)
            .FirstOrDefault(t => t.Id == trainingId);

        if (training is null)
            throw new EntityNotFoundException(typeof(TrainingPlan), trainingId);

        training.SetExerciseDetails(exerciseId, dto.Kg, dto.Sets, dto.Reps, dto.Note);
        var result = _context.SaveChanges() > 0;
        if (!result)
            throw new ApplicationException("Failed to set exercise details");
    }
}