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

        // builder.OwnsMany(x => x.Sets2, setBuilder =>
        // {
        //     setBuilder.HasKey("Id");
        //     setBuilder.Property(x => x.Kg);
        //     setBuilder.Property(x => x.Reps);
        // });
    }
}