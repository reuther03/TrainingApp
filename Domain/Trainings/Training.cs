using Domain.Abstractions;
using Domain.Abstractions.Exceptions;
using Domain.Users;

namespace Domain.Trainings;

public class Training : Entity
{
    public string Name { get; private set; } = default!;
    public DateTime StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }
    public ICollection<Exercise> Exercises { get; private set; } = default!;
    public Guid UserId { get; set; }
    public bool IsCompleted => EndTime.HasValue;

    private Training()
    {
    }

    private Training(Guid id, string name, IEnumerable<Exercise> exercises, Guid userId)
        : base(id)
    {
        Name = name;
        StartTime = DateTime.Now;
        EndTime = null;
        Exercises = exercises.ToList();
        UserId = userId;
    }

    public static Training Create(Guid id, string name, IEnumerable<Exercise> exercises, Guid userId)
    {
        return new Training(id, name, exercises, userId);
    }

    // w serwisie pobrac Training na bazie id, includować exercises
    public void SetExerciseDetails(Guid exerciseId, double kg, int sets, int reps, string? note)
    {
        var exercise = Exercises.FirstOrDefault(x => x.Id == exerciseId);

        if (exercise is null)
            throw new EntityNotFoundException(typeof(Exercise), exerciseId);

        exercise.Update(kg, sets, reps, note);
    }

    public void Complete()
    {
        EndTime = DateTime.Now;
    }
}