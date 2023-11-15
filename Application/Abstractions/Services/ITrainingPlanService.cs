using Application.Features.TrainingPlanExercises.Dto;
using Application.Features.TrainingPlans.Dto;

namespace Application.Abstractions.Services;

public interface ITrainingPlanService
{
    TrainingPlanDetailsDto GetTrainingPlanDetails(Guid id);
    IEnumerable<TrainingPlanDetailsDto> GetUserAndGlobalTrainingPlans();
    // TrainingPlanDetailsDto -> { Guid Id, string Name, List<TrainingPlanExerciseDetailsDto> Exercises }
    IEnumerable<TrainingPlanDto> GetAllPlans();
    Guid CreateTrainingPlan(CreateTrainingPlanDto dto);
    void AddNewTrainingPlanExercise(Guid id, CreateTrainingPlanExerciseDto dto);
    void AddExistingTrainingPlanExercise(Guid id, Guid exerciseId);
    void DeleteTrainingPlan(Guid id);
    void DeleteTrainingPlanExercise(Guid id, Guid exerciseId);
}