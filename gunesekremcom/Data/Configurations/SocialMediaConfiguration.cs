using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Url).HasMaxLength(500).IsRequired();
            builder.Property(s => s.Icon).HasMaxLength(1000).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
            builder.Property(s => s.order).HasDefaultValue(1);
            builder.Property(s => s.ClickCount).HasDefaultValue(1);
        }
    }
}
