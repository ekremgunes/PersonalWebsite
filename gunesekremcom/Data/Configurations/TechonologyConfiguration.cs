using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class TechonologyConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Icon).HasMaxLength(1000).IsRequired();
            builder.Property(t => t.ColorCode).HasMaxLength(50).IsRequired();
            builder.Property(t => t.order).HasDefaultValue(1);
        }
    }
}
