using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(100).IsRequired();

            builder.HasData(
            new User
            {
                Id = 1,
                Password = "12345",
                Email = "email@example.com",
                Name = "Ekrem"
            },
            new User
            {
                Id = 2,
                Email = "email@example.com",
                Password = "12345",
                Name = "Gunes"
            });
        }
    }
}
