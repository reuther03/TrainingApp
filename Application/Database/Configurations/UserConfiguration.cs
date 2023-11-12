using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedBy)
            .IsRequired(false);
        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired(false);
        builder.Property(e => e.UpdatedBy)
            .IsRequired(false);

        builder.Property(e => e.Username)
            .IsRequired();

        builder.Property(e => e.Email)
            .IsRequired();

        builder.Property(e => e.BirthDate)
            .IsRequired();

        builder.Property(e => e.Password)
            .IsRequired();

        builder.Property(e => e.Role)
            .IsRequired();

        builder.HasData(new List<User>
        {
            User.CreateAdmin("admin", "admin@email.com", DateTime.Now.AddYears(-20), "admin"),
            User.CreateUser("user", "user@email.com", DateTime.Now.AddYears(-18), "user")
        });
    }
}