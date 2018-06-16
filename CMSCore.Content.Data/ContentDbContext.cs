namespace CMSCore.Content.Data
{
    using CMSCore.Content.Data.Extensions;
    using CMSCore.Content.Models;
    using Microsoft.EntityFrameworkCore;

    public class ContentDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FeedItem> FeedItems { get; set; }

        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ContentDbContext()
        {
        }

        public ContentDbContext(DbContextOptions options) : base(options)
        {
        }

        public ContentDbContext(string connectionString) : this(GetOptions(connectionString))
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConnectionConst.SqlServer);
            }

            base.OnConfiguring(optionsBuilder);
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            //return new DbContextOptionsBuilder().UseNpgsql(connectionString).Options;
            return new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(x => x.IdentityUserId)
                .IsUnique();
        }
    }
}