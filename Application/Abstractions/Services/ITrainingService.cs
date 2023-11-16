using Application.Features.Trainings.Dto;

namespace Application.Abstractions.Services;

public interface ITrainingService
{
    Guid StartTraining(Guid trainingPlanId);
    void SetExerciseDetails(Guid trainingId, Guid exerciseId, ExerciseDetailsDto dto);
    Guid CompleteTraining(Guid trainingId);
}