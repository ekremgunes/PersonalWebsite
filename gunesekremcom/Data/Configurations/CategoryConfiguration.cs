using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(50);
            builder.HasMany(c => c.Posts).WithOne(c => c.Category).HasForeignKey(p => p.CategoryId);
            builder.HasData(new Category
            {
                Id = 1,
                Title = "Default Category",
            });
        }
    }
}
