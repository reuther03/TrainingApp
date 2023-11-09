using Domain.TrainingPlans;

namespace Application.Features.TrainingPlanExercises.Dto;

public class CreateTrainingPlanExerciseDto
{
    public string Name { get; set; } = default!;
    public MuscleGroup MuscleGroup { get; set; } = default!;
    public string? Description { get; set; }
    public string? ImgUrl { get; set; }
    public string? TutorialUrl { get; set; }

    public TrainingPlanExercise ToEntity()
    {
        return TrainingPlanExercise.Create(Name, MuscleGroup, Description, ImgUrl, TutorialUrl);
    }
}