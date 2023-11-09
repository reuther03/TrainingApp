namespace Application.Features.TrainingPlans.Dto;

public class TrainingPlanDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int Exercises { get; set; }
}