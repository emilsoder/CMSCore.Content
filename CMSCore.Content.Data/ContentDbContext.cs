using System;
using CMSCore.Content.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CMSCore.Content.Data
{
    public class ContentDbContext : DbContext
    {
        private const string _dbConnectionString =
            "Data Source=STO-PC-681;Initial Catalog=cmscore-content;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //public ContentDbContext(DbContextOptions options) : base(options) { }

        //public ContentDbContext()
        //{

        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Page> Pages { get; set; }

        public DbSet<Feed> Feeds { get; set; }
        public DbSet<FeedItem> FeedItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasKey(x => x.Id);
            //modelBuilder.Entity<Page>().HasKey(x => x.Id);

            //modelBuilder.Entity<Feed>().HasKey(x => x.Id);
            //modelBuilder.Entity<FeedItem>().HasKey(x => x.Id);
            //modelBuilder.Entity<Tag>().HasKey(x => x.Id);
            //modelBuilder.Entity<Comment>().HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .HasIndex(x => x.IdentityUserId)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}