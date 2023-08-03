using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class EmailAddressConfiguration : IEntityTypeConfiguration<EmailAddress>
    {
        public void Configure(EntityTypeBuilder<EmailAddress> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ConfirmCode).IsRequired().HasMaxLength(200);
            builder.Property(x => x.isConfirmed).HasDefaultValue(false);
            builder.Property(x => x.SubDate).HasDefaultValueSql("getdate()");
        }
    }
}
