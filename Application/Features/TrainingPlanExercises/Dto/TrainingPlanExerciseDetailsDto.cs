using Domain.TrainingPlans;

namespace Application.Features.TrainingPlanExercises.Dto;

public class TrainingPlanExerciseDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public MuscleGroup MuscleGroup { get; set; }
    public string? Description { get; set; }
    public string? ImgUrl { get; set; }
    public string? TutorialUrl { get; set; }
}