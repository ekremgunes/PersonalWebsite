using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ViewCount).HasDefaultValue(10);
            builder.Property(p => p.ReadingTime).IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Date).HasDefaultValueSql("getdate()");
            builder.Property(p => p.Image).HasMaxLength(500).IsRequired();
        }
    }
}
