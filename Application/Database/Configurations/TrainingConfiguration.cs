using Domain.Trainings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Database.Configurations;

public class TrainingConfiguration : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.StartTime);
        builder.Property(x => x.EndTime);

        builder
            .HasMany(t => t.Exercises)
            .WithOne(x => x.Training)
            .HasForeignKey(x => x.TrainingId);
    }
}