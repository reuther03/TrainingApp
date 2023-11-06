using Application.Dto.TrainingPlan;

namespace Application.Abstractions.Services;

public interface ITrainingPlanExerciseService
{
    IEnumerable<TrainingPlanExerciseDto> GetAllExercises();
    TrainingPlanExerciseDetailsDto GetExerciseDetails(Guid id);
    Guid CreateExercise(CreateTrainingPlanExerciseDto dto);
    void DeleteExercise(Guid id);
    Guid UpdateExercise(Guid id, CreateTrainingPlanExerciseDto dto);

}