using Domain.Abstractions;

namespace Domain.TrainingPlans;

public class TrainingPlan : Entity
{
    public string Name { get; private set; } = default!;
    public ICollection<TrainingPlanExercise> Exercises { get; private set; } = new List<TrainingPlanExercise>();

    private TrainingPlan()
    {
    }

    private TrainingPlan(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public static TrainingPlan Create(string name, IEnumerable<TrainingPlanExercise> exercises)
    {
        var trainingPlan = new TrainingPlan(Guid.NewGuid(), name);
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