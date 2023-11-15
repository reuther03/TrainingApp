using Domain.Abstractions;

namespace Domain.TrainingPlans;

public class TrainingPlan : Entity
{
    public string Name { get; private set; } = default!;
    public bool IsGlobal { get; private set; }
    public ICollection<TrainingPlanExercise> Exercises { get; private set; } = new List<TrainingPlanExercise>();

    private TrainingPlan()
    {
    }

    private TrainingPlan(Guid id, string name, bool isGlobal) : base(id)
    {
        Name = name;
        IsGlobal = isGlobal;
    }

    public static TrainingPlan Create(string name, bool isGlobal, IEnumerable<TrainingPlanExercise> exercises)
    {
        var trainingPlan = new TrainingPlan(Guid.NewGuid(), name, isGlobal);
        trainingPlan.AddExercises(exercises.ToArray());

        return trainingPlan;
    }

    public void AddExercises(params TrainingPlanExercise[] exercises)
    {
        foreach (var exercise in exercises)
            Exercises.Add(exercise);
    }

    public void RemoveExercise(TrainingPlanExercise exercise)
    {
        Exercises.Remove(exercise);
    }
}