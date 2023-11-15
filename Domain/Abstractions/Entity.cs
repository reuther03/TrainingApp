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

// NOTE: value objects
// public abstract class ValueObject
// {
//     protected abstract IEnumerable<object> GetEqualityComponents();
// }
//
// public class Name : ValueObject
// {
//     public string First { get; }
//     public string Last { get; }
//
//     public Name(string first, string last)
//     {
//         First = first;
//         Last = last;
//     }
//
//     protected override IEnumerable<object> GetEqualityComponents()
//     {
//         yield return First;
//         yield return Last;
//     }
// }