using Domain.Trainings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Database.Configurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Sets);
        builder.Property(x => x.Reps);
        builder.Property(x => x.Note);

        builder
            .HasOne(x => x.TrainingPlanExercise)
            .WithMany()
            .HasForeignKey(x => x.TrainingPlanExerciseId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}