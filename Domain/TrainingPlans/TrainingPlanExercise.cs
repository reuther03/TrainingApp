using Domain.Abstractions;

namespace Domain.TrainingPlans;

public class TrainingPlanExercise : Entity
{
    public string Name { get; private set; } = default!;
    public bool IsGlobal { get; private set; }
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
        bool isGlobal,
        MuscleGroup muscleGroup,
        string? description,
        string? imgUrl,
        string? tutorialUrl
    ) : base(id)
    {
        Name = name;
        IsGlobal = isGlobal;
        MuscleGroup = muscleGroup;
        Description = description;

        if (Uri.IsWellFormedUriString(imgUrl, UriKind.Absolute))
            ImgUrl = imgUrl;

        if (Uri.IsWellFormedUriString(tutorialUrl, UriKind.Absolute))
            TutorialUrl = tutorialUrl;
    }

    public static TrainingPlanExercise Create(
        string name,
        bool isGlobal,
        MuscleGroup muscleGroup,
        string? description = null,
        string? imgUrl = null,
        string? tutorialUrl = null
    )
    {
        return new TrainingPlanExercise(Guid.NewGuid(), name, isGlobal, muscleGroup, description, imgUrl, tutorialUrl);
    }

    public void Update(string name, MuscleGroup muscleGroup, string? description, string? imgUrl, string? tutorialUrl)
    {
        Name = name;
        MuscleGroup = muscleGroup;
        Description = description;

        if (Uri.IsWellFormedUriString(imgUrl, UriKind.Absolute))
            ImgUrl = imgUrl;

        if (Uri.IsWellFormedUriString(tutorialUrl, UriKind.Absolute))
            TutorialUrl = tutorialUrl;
    }
}

// TODO: Url value object example
// public class ImageUrl
// {
//     public string Value { get; }
//
//     public ImageUrl(string value)
//     {
//         if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
//             throw new ArgumentException("Invalid image url");
//
//         Value = value;
//     }
// }