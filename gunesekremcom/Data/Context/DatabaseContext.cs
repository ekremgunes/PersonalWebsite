using gunesekremcom.Data.Configurations;
using gunesekremcom.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.Data.Context
{
    public class DatabaseContext : DbContext
    {

        public DbSet<User> Users => Set<User>();
        public DbSet<EmailAddress> EmailAddresses => Set<EmailAddress>();
        public DbSet<Statistic> Statistics => Set<Statistic>();

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Certificate> Certifications => Set<Certificate>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Education> Educations => Set<Education>();
        public DbSet<Reply> Replies => Set<Reply>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Saying> Sayings => Set<Saying>();
        public DbSet<Seo> Seo => Set<Seo>();
        public DbSet<Setting> Settings => Set<Setting>();
        public DbSet<SocialMedia> SocialMedias => Set<SocialMedia>();
        public DbSet<Technology> Technologies => Set<Technology>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CertificateConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new EducationConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ReplyConfiguration());
            modelBuilder.ApplyConfiguration(new SayingConfiguration());
            modelBuilder.ApplyConfiguration(new SeoConfiguration());
            modelBuilder.ApplyConfiguration(new SocialMediaConfiguration());
            modelBuilder.ApplyConfiguration(new SettingsConfiguration());
            modelBuilder.ApplyConfiguration(new TechonologyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EmailAddressConfiguration());
            modelBuilder.ApplyConfiguration(new StatisticConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER03;Database=gunesekrem;Trusted_Connection=True;",
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }
    }
}
