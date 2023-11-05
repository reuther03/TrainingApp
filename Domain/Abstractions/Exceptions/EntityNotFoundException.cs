using System.Reflection;

namespace Domain.Abstractions.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(MemberInfo entityType, Guid id)
        : base($"{entityType.Name} with '{id}' was not found.")
    {
    }
}