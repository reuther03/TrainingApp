using Application.Features.TrainingPlanExercises.Dto;

namespace Application.Abstractions.Services;

public interface ITrainingPlanExerciseService
{
    IEnumerable<TrainingPlanExerciseDto> GetAllExercises();
    IEnumerable<TrainingPlanExerciseDetailsDto> GetUserAndGlobalTrainingPlanExercise();

    TrainingPlanExerciseDetailsDto GetExerciseDetails(Guid id);
    Guid CreateExercise(CreateTrainingPlanExerciseDto dto);
    void DeleteExercise(Guid id);
    Guid UpdateExercise(Guid id, CreateTrainingPlanExerciseDto dto);

}