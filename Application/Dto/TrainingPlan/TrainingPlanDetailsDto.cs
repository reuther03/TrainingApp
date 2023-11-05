namespace Application.Dto.TrainingPlan;

public class TrainingPlanDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<TrainingPlanExerciseDetailsDto> Exercises { get; set; }
}