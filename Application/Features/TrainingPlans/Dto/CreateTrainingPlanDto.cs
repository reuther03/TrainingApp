using Application.Features.TrainingPlanExercises.Dto;

namespace Application.Features.TrainingPlans.Dto;

public class CreateTrainingPlanDto
{
    public string Name { get; set; }
    public List<CreateTrainingPlanExerciseDto> Exercises { get; set; }
    public List<Guid> ExistingExercises { get; set; }
    public Guid CreatedBy { get; set; }
}