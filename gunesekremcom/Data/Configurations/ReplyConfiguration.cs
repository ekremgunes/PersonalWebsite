using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).HasMaxLength(100).IsRequired();
            builder.Property(r => r.ReplyText).HasMaxLength(500).IsRequired();
            builder.Property(r => r.Date).HasDefaultValueSql("getdate()");
            builder.Property(r => r.Email).HasMaxLength(100).IsRequired();
            builder.HasOne(r => r.Comment).WithMany(c => c.Replies).HasForeignKey(r => r.CommentId);
        }
    }
}
