using Domain.Abstractions;

namespace Domain.Trainings;

public class Training : Entity
{
    public string Name { get; private set; } = default!;
    public DateTime StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }
    public ICollection<Exercise> Exercises { get; private set; } = default!;

    private Training()
    {
    }

    private Training(Guid id, DateTime startTime)
        : base(id)
    {
        StartTime = startTime;
        EndTime = null;
    }

    public static Training Create()
    {
        return new Training(Guid.NewGuid(), DateTime.Now);
    }
}