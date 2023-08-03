using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class SeoConfiguration : IEntityTypeConfiguration<Seo>
    {
        public void Configure(EntityTypeBuilder<Seo> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasData(new Seo { SeoHTML = "<meta name=\"description\" content=\"Ekrem Güneş\" />", Id = 1 });
        }
    }
}
