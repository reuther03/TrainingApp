using Domain.Abstractions;

namespace Domain.TrainingPlans;

public class TrainingPlanExercise : Entity
{
    public string Name { get; private set; } = default!;
    public MuscleGroup MuscleGroup { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? ImgUrl { get; private set; }
    public string? TutorialUrl { get; private set; }

    private TrainingPlanExercise()
    {
    }

    private TrainingPlanExercise(
        Guid id,
        string name,
        MuscleGroup muscleGroup,
        string? description,
        string? imgUrl,
        string? tutorialUrl
    ) : base(id)
    {
        Name = name;
        MuscleGroup = muscleGroup;
        Description = description;
        ImgUrl = imgUrl;
        TutorialUrl = tutorialUrl;
    }

    public static TrainingPlanExercise Create(
        string name,
        MuscleGroup muscleGroup,
        string? description = null,
        string? imgUrl = null,
        string? tutorialUrl = null
    )
    {
        var trainingPlanExercise = new TrainingPlanExercise(Guid.NewGuid(), name, muscleGroup, description, imgUrl, tutorialUrl);
        return trainingPlanExercise;
    }
}