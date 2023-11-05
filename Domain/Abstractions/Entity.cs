﻿namespace Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; set; }

    protected Entity()
    {
    }

    protected Entity(Guid id)
    {
        Id = id;
    }
}