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

    // public override int SaveChanges()
    // {
    //     var entries = ChangeTracker
    //         .Entries()
    //         .Where(e => e.Entity is Entity && (
    //             e.State == EntityState.Added
    //             || e.State == EntityState.Modified));
    //
    //     foreach (var entityEntry in entries)
    //     {
    //         if (entityEntry.State == EntityState.Added)
    //         {
    //             ((Entity) entityEntry.Entity).CreatedAt = DateTime.UtcNow;
    //             ((Entity) entityEntry.Entity).CreatedBy = _userContext.UserId ?? Guid.Empty;
    //         }
    //         if (entityEntry.State == EntityState.Modified)
    //         {
    //             ((Entity) entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
    //             ((Entity) entityEntry.Entity).UpdatedBy = _userContext.UserId ?? Guid.Empty;
    //         }
    //     }
    //
    //     return base.SaveChanges();
    // }
}