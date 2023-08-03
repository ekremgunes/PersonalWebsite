using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.Star).HasDefaultValue(3).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Definition).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Image).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Order).HasDefaultValue(3);
        }
    }
}
