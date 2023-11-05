using Domain.Abstractions;
using Domain.TrainingPlans;

namespace Domain.Trainings;

public class Exercise : Entity
{
    public double Kg { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public string? Note { get; set; }


    public Guid TrainingId { get; set; }
    public Training Training { get; set; }

    public Guid TrainingPlanExerciseId { get; set; }
    public TrainingPlanExercise TrainingPlanExercise { get; set; }

    private Exercise()
    {
    }
}