using Application.Abstractions.Services;
using Application.Database;
using Application.Features.TrainingPlanExercises.Dto;
using Application.Features.TrainingPlans.Dto;
using Domain.Abstractions.Exceptions;
using Domain.TrainingPlans;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.TrainingPlans;

class TrainingPlanService : ITrainingPlanService
{
    private readonly TrainingDbContext _context;

    public TrainingPlanService(TrainingDbContext context)
    {
        _context = context;
    }

    public TrainingPlanDetailsDto GetTrainingPlanDetails(Guid id)
    {
        var trainingPlan = _context.TrainingPlans
            .Include(tp => tp.Exercises)
            .Where(tp => tp.Id == id)
            .Select(tp => new TrainingPlanDetailsDto
            {
                Id = tp.Id,
                Name = tp.Name,
                Exercises = tp.Exercises
                    .Select(e => new TrainingPlanExerciseDetailsDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        MuscleGroup = e.MuscleGroup,
                        Description = e.Description,
                        ImgUrl = e.ImgUrl,
                        TutorialUrl = e.TutorialUrl
                    })
                    .ToList()
            })
            .AsSplitQuery()
            .FirstOrDefault();

        if (trainingPlan is null)
            throw new EntityNotFoundException(typeof(TrainingPlan), id);

        return trainingPlan;
        //     .Select(tp => new TrainingPlanDetailsDto
        // {
        //     Id = tp.Id,
        //     Name = tp.Name,
        //     Exercises = tp.Exercises.Select(e => new TrainingPlanExerciseDetailsDto
        //     {
        //         Id = default,
        //         Name = null,
        //         MuscleGroup = MuscleGroup.Chest,
        //         Description = null,
        //         ImgUrl = null,
        //         TutorialUrl = null
        //     }).ToList()
        // })
    }

    public IEnumerable<TrainingPlanDto> GetAllPlans()
    {
        var trainingPlans = _context.TrainingPlans
            .Include(tp => tp.Exercises)
            .AsSplitQuery()
            .Select(tp => new TrainingPlanDto
            {
                Id = tp.Id,
                Name = tp.Name,
                Exercises = tp.Exercises.Count
            })
            .ToList();

        return trainingPlans;
    }

    public Guid CreateTrainingPlan(CreateTrainingPlanDto dto)
    {
        var exercises = new List<TrainingPlanExercise>();
        foreach (var exerciseDto in dto.Exercises)
        {
            var exercise = exerciseDto.ToEntity();
            // var exercise = TrainingPlanExercise.Create(
            //     exerciseDto.Name,
            //     exerciseDto.MuscleGroup,
            //     exerciseDto.Description,
            //     exerciseDto.ImgUrl,
            //     exerciseDto.TutorialUrl
            // );

            exercises.Add(exercise);
        }

        var existingExercises = new List<TrainingPlanExercise>();
        foreach (var exerciseId in dto.ExistingExercises)
        {
            var exercise = _context.TrainingPlanExercises
                .FirstOrDefault(tpe => tpe.Id == exerciseId);

            if (exercise is null)
                continue;

            existingExercises.Add(exercise);
        }

        var allExercises = exercises.Concat(existingExercises);
        var trainingPlan = TrainingPlan.Create(dto.Name, allExercises);

        _context.TrainingPlans.Add(trainingPlan);
        _context.SaveChanges();

        return trainingPlan.Id;
    }

    public void AddNewTrainingPlanExercise(Guid id, CreateTrainingPlanExerciseDto dto)
    {
        var trainingPlan = _context.TrainingPlans
            .Include(tp => tp.Exercises)
            .AsSplitQuery()
            .FirstOrDefault(tp => tp.Id == id);

        if (trainingPlan is null)
            throw new EntityNotFoundException(typeof(TrainingPlan), id);

        var trainingPlanExercise = TrainingPlanExercise.Create(
            dto.Name,
            dto.MuscleGroup,
            dto.Description,
            dto.ImgUrl,
            dto.TutorialUrl
        );

        trainingPlan.AddExercises(trainingPlanExercise);
        _context.TrainingPlanExercises.Add(trainingPlanExercise);
        _context.SaveChanges();
    }

    public void AddExistingTrainingPlanExercise(Guid id, Guid exerciseId)
    {
        var trainingPlan = _context.TrainingPlans
            .Include(tp => tp.Exercises)
            .AsSplitQuery()
            .FirstOrDefault(tp => tp.Id == id);

        if (trainingPlan is null)
            throw new EntityNotFoundException(typeof(TrainingPlan), id);

        var trainingPlanExercise = _context.TrainingPlanExercises
            .FirstOrDefault(tpe => tpe.Id == exerciseId);

        if (trainingPlanExercise is null)
            throw new EntityNotFoundException(typeof(TrainingPlanExercise), id);

        trainingPlan.AddExercises(trainingPlanExercise);
        _context.SaveChanges();
    }

    public void DeleteTrainingPlan(Guid id)
    {
        var trainingPlan = _context.TrainingPlans
            .FirstOrDefault(tp => tp.Id == id);

        if (trainingPlan is null)
            throw new EntityNotFoundException(typeof(TrainingPlan), id);

        _context.Remove(trainingPlan);
        _context.SaveChanges();
    }

    public void DeleteTrainingPlanExercise(Guid id, Guid exerciseId)
    {
        var trainingPlan = _context.TrainingPlans
            .Include(tp => tp.Exercises)
            .AsSplitQuery()
            .FirstOrDefault(tp => tp.Id == id);

        if (trainingPlan is null)
            throw new EntityNotFoundException(typeof(TrainingPlan), id);

        var exercise = trainingPlan.Exercises
            .FirstOrDefault(e => e.Id == exerciseId);

        if (exercise is null)
            throw new EntityNotFoundException(typeof(TrainingPlanExercise), exerciseId);

        trainingPlan.RemoveExercise(exercise);
        _context.SaveChanges();
    }


    // public Guid AddExercise(AddTrainingPlanExerciseDto dto)
    // {
    //     var exercise = TrainingPlanExercise.Create("name", MuscleGroup.Abs);
    //
    //     // pobranie TrainingPlan z DB
    //     var trainingPlan = new TrainingPlan(); // dbContext.TrainingPlans.FirstOrDefault(x => x.Id == dto.TrainingPlanId)
    //
    //     trainingPlan.AddExercise(exercise);
    //
    //     // dbContext.SaveChanges()
    //
    //     // return trainingPlan.Id;
    // }
}