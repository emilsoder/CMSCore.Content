using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CMSCore.Content.GrainInterfaces.Types;
using CMSCore.Content.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CMSCore.Content.Data
{
    public class ContentDbContext : DbContext
    {
        public ContentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Page> Pages { get; set; }

        public DbSet<Feed> Feeds { get; set; }
        public DbSet<FeedItem> FeedItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Page>().HasKey(x => x.Id);

            modelBuilder.Entity<Feed>().HasKey(x => x.Id);
            modelBuilder.Entity<FeedItem>().HasKey(x => x.Id);
            modelBuilder.Entity<Tag>().HasKey(x => x.Id);
            modelBuilder.Entity<Comment>().HasKey(x => x.Id);


            modelBuilder.Entity<User>()
                .HasIndex(x => x.IdentityUserId)
                .IsUnique();
        }
    }
}
 