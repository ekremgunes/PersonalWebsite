using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Host).HasMaxLength(100).IsRequired();
            builder.Property(c => c.CredentialUrl).HasMaxLength(500);
            builder.Property(c => c.Title).HasMaxLength(100).IsRequired();
            builder.Property(c => c.order).HasDefaultValue(1);
        }
    }
}
