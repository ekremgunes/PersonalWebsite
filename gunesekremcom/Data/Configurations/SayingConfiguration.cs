using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class SayingConfiguration : IEntityTypeConfiguration<Saying>
    {
        public void Configure(EntityTypeBuilder<Saying> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Owner).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Content).HasMaxLength(400).IsRequired();
        }
    }
}
