namespace Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; set; }

    public Guid? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }

    protected Entity()
    {
    }

    protected Entity(Guid id)
    {
        Id = id;
    }
}