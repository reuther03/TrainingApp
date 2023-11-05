using Domain.TrainingPlans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Database.Configurations;

public class TrainingPlanExerciseConfiguration : IEntityTypeConfiguration<TrainingPlanExercise>
{
    public void Configure(EntityTypeBuilder<TrainingPlanExercise> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired();

        builder.Property(e => e.MuscleGroup)
            .IsRequired();

        builder.Property(e => e.Description);

        builder.Property(e => e.ImgUrl);

        builder.Property(e => e.TutorialUrl);
    }
}