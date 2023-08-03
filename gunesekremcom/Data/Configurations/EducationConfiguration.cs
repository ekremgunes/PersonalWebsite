using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Url).HasMaxLength(300).IsRequired();
            builder.Property(e => e.Title).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Content).IsRequired();
            builder.Property(e => e.Definition).HasMaxLength(300).IsRequired();
            builder.Property(e => e.Slug).HasMaxLength(250).IsRequired();
            builder.Property(e => e.Order).HasDefaultValue(1);
            builder.Property(e => e.StudentCount).HasDefaultValue(1).IsRequired();
            builder.Property(e => e.ViewCount).HasDefaultValue(10);

        }
    }
}
