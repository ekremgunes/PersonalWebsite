using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gunesekremcom.Data.Configurations
{
    public class SettingsConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
            builder.Property(s => s.SchoolUrl).HasMaxLength(350).IsRequired();
            builder.Property(s => s.Company).HasMaxLength(100);
            builder.Property(s => s.ProfilePhoto).HasMaxLength(1000).IsRequired();
            builder.Property(s => s.School).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Email).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Definition).HasMaxLength(500).IsRequired();
            builder.Property(s => s.AboutArticle).HasMaxLength(1000).IsRequired();
            builder.Property(s => s.CompanyUrl).HasMaxLength(350);
            builder.Property(s => s.Location).HasMaxLength(50).IsRequired();
            builder.Property(s => s.LogoImage).HasMaxLength(1000).IsRequired();
            builder.Property(s => s.Icon).HasMaxLength(1000).IsRequired();
            builder.Property(s => s.VisitorCount).HasDefaultValue(1);

            builder.HasData(new Setting
            {
                Id = 1,
                Company = "company name",
                CompanyUrl = "company url",
                Definition = "About me,lorem ipsum dolor sit amet lorem ipsumbel amet dolor sit.",
                Email = "yourmail@gmail.com",
                Location = "TR",
                LogoImage = "default.jpg",
                Name = "Ekrem Güneş",
                ProfilePhoto = "default.jpg",
                School = "your school name",
                SchoolUrl = "your school web adress",
                AboutArticle = "Hi! Lorem Psim dolor sitema asdk asda sdasdas asdasd ads sadsd",
                Icon = "icon.png",
                VisitorCount = 1
            });
        }
    }
}
