using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class StatisticConfiguration : IEntityTypeConfiguration<Statistic>
    {
        public void Configure(EntityTypeBuilder<Statistic> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.VisitorCount).HasDefaultValue(0).IsRequired();
            builder.Property(x => x.Date).HasDefaultValueSql("getdate()").IsRequired();
        }
    }
}
