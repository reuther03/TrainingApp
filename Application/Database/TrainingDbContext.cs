using Domain.TrainingPlans;
using Domain.Trainings;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Database;

public class TrainingDbContext : DbContext
{
    public DbSet<TrainingPlan> TrainingPlans { get; set; } = default!;
    public DbSet<TrainingPlanExercise> TrainingPlanExercises { get; set; } = default!;
    public DbSet<Exercise> Exercises { get; set; } = default!;
    public DbSet<Training> Trainings { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;

    public TrainingDbContext(DbContextOptions<TrainingDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrainingDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}