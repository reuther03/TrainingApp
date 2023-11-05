namespace Application.Dto.TrainingPlan;

public class CreateTrainingPlanDto
{
    public string Name { get; set; }
    public List<CreateTrainingPlanExerciseDto> Exercises { get; set; }
    public List<Guid> ExistingExercises { get; set; }
}