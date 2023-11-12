using Application.Abstractions.Auth;
using Domain.Abstractions;
using Domain.TrainingPlans;
using Domain.Trainings;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Database;

public class TrainingDbContext : DbContext
{
    private readonly IUserContext _userContext;

    public DbSet<TrainingPlan> TrainingPlans { get; set; } = default!;
    public DbSet<TrainingPlanExercise> TrainingPlanExercises { get; set; } = default!;
    public DbSet<Exercise> Exercises { get; set; } = default!;
    public DbSet<Training> Trainings { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;

    public TrainingDbContext(DbContextOptions<TrainingDbContext> options, IUserContext userContext)
        : base(options)
    {
        _userContext = userContext;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrainingDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e is { Entity: Entity, State: EntityState.Added or EntityState.Modified });

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(nameof(Entity.CreatedAt)).CurrentValue = DateTime.UtcNow;
                entry.Property(nameof(Entity.CreatedBy)).CurrentValue = _userContext.UserId ?? Guid.Empty;
            }
            if (entry.State == EntityState.Modified)
            {
                entry.Property(nameof(Entity.UpdatedAt)).CurrentValue = DateTime.UtcNow;
                entry.Property(nameof(Entity.UpdatedBy)).CurrentValue = _userContext.UserId ?? Guid.Empty;
            }
        }

        return base.SaveChanges();
    }
}