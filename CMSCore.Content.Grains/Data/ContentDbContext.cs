namespace CMSCore.Content.Grains.Data
{
    using Configuration;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ContentDbContext : DbContext
    {
        public ContentDbContext(DbContextOptions options) : base(options)
        {
            
        }

        //private readonly IDataConfiguration _dataConfiguration;

        public DbSet<Comment> Comments { get; set; }
        public DbSet<FeedItem> FeedItems { get; set; }

        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        //public ContentDbContext(IDataConfiguration dataConfiguration)
        //{
        //    _dataConfiguration = dataConfiguration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_dataConfiguration.ContentConnection);
        // }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(x => x.IdentityUserId)
                .IsUnique();


            modelBuilder.Entity<Page>().HasOne(x => x.Feed).WithOne(x => x.Page).HasForeignKey(typeof(Page), "FeedId");
            modelBuilder.Entity<Feed>().HasOne(x => x.Page).WithOne(x => x.Feed).HasForeignKey(typeof(Feed), "PageId");
        }
    }
}