using Domain.Abstractions;
using Domain.TrainingPlans;

namespace Domain.Trainings;

public class Exercise : Entity
{
    public double Kg { get; private set; }
    public int Sets { get; private set; }
    public int Reps { get; private set; }
    public string? Note { get; private set; }

    public string Name { get; private set; }
    public MuscleGroup MuscleGroup { get; private set; }
    public string? Description { get; private set; }
    public string? ImgUrl { get; private set; }
    public string? TutorialUrl { get; private set; }

    public Guid TrainingId { get; private set; }
    public virtual Training Training { get; private set; } = default!;

    private Exercise(
        Guid id,
        string name,
        MuscleGroup muscleGroup,
        string? description,
        string? imgUrl,
        string? tutorialUrl,
        Guid trainingId
    )
        : base(id)
    {
        Kg = 0;
        Sets = 0;
        Reps = 0;

        Name = name;
        MuscleGroup = muscleGroup;
        Description = description;
        ImgUrl = imgUrl;
        TutorialUrl = tutorialUrl;

        TrainingId = trainingId;
    }

    public static Exercise Create(
        string name,
        MuscleGroup muscleGroup,
        string? description,
        string? imgUrl,
        string? tutorialUrl,
        Guid trainingId
    )
    {
        return new Exercise(
            Guid.NewGuid(),
            name,
            muscleGroup,
            description,
            imgUrl,
            tutorialUrl,
            trainingId
        );
    }

    public void Update(double kg, int sets, int reps, string? note)
    {
        if (kg < 0 || sets < 0 || reps < 0)
            throw new ArgumentException("Negative values are not allowed");

        Kg = kg;
        Sets = sets;
        Reps = reps;
        Note = note;
    }
}