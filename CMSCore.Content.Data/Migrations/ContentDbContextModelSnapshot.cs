﻿namespace CMSCore.Content.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;

    [DbContext(typeof(ContentDbContext))]
    internal class ContentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rc1-32029")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CMSCore.Content.Models.Comment", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("Date");

                b.Property<string>("EntityId");

                b.Property<string>("FeedItemId");

                b.Property<string>("FullName");

                b.Property<bool>("Hidden");

                b.Property<bool>("IsActiveVersion");

                b.Property<bool>("MarkedToDelete");

                b.Property<DateTime>("Modified");

                b.Property<string>("Text");

                b.Property<string>("UserId");

                b.Property<int>("Version");

                b.HasKey("Id");

                b.ToTable("Comments");
            });

            modelBuilder.Entity("CMSCore.Content.Models.Feed", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("Date");

                b.Property<string>("EntityId");

                b.Property<bool>("Hidden");

                b.Property<bool>("IsActiveVersion");

                b.Property<bool>("MarkedToDelete");

                b.Property<DateTime>("Modified");

                b.Property<string>("Name");

                b.Property<string>("NormalizedName");

                b.Property<string>("PageId");

                b.Property<string>("UserId");

                b.Property<int>("Version");

                b.HasKey("Id");

                b.ToTable("Feeds");
            });

            modelBuilder.Entity("CMSCore.Content.Models.FeedItem", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<bool>("CommentsEnabled");

                b.Property<string>("Content");

                b.Property<DateTime>("Date");

                b.Property<string>("Description");

                b.Property<string>("EntityId");

                b.Property<string>("FeedId");

                b.Property<bool>("Hidden");

                b.Property<bool>("IsActiveVersion");

                b.Property<bool>("MarkedToDelete");

                b.Property<DateTime>("Modified");

                b.Property<string>("NormalizedTitle");

                b.Property<string>("Title");

                b.Property<string>("UserId");

                b.Property<int>("Version");

                b.HasKey("Id");

                b.ToTable("FeedItems");
            });

            modelBuilder.Entity("CMSCore.Content.Models.Page", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Content");

                b.Property<DateTime>("Date");

                b.Property<string>("EntityId");

                b.Property<bool>("FeedEnabled");

                b.Property<bool>("Hidden");

                b.Property<bool>("IsActiveVersion");

                b.Property<bool>("MarkedToDelete");

                b.Property<DateTime>("Modified");

                b.Property<string>("Name");

                b.Property<string>("NormalizedName");

                b.Property<string>("UserId");

                b.Property<int>("Version");

                b.HasKey("Id");

                b.ToTable("Pages");
            });

            modelBuilder.Entity("CMSCore.Content.Models.Tag", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("Date");

                b.Property<string>("EntityId");

                b.Property<string>("FeedItemId");

                b.Property<bool>("Hidden");

                b.Property<bool>("IsActiveVersion");

                b.Property<bool>("MarkedToDelete");

                b.Property<DateTime>("Modified");

                b.Property<string>("Name");

                b.Property<string>("NormalizedName");

                b.Property<string>("UserId");

                b.Property<int>("Version");

                b.HasKey("Id");

                b.ToTable("Tags");
            });

            modelBuilder.Entity("CMSCore.Content.Models.User", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("Date");

                b.Property<string>("Email");

                b.Property<string>("EntityId");

                b.Property<string>("FirstName");

                b.Property<bool>("Hidden");

                b.Property<string>("IdentityUserId");

                b.Property<bool>("IsActiveVersion");

                b.Property<string>("LastName");

                b.Property<bool>("MarkedToDelete");

                b.Property<DateTime>("Modified");

                b.Property<string>("UserId");

                b.Property<int>("Version");

                b.HasKey("Id");

                b.HasIndex("IdentityUserId")
                    .IsUnique()
                    .HasFilter("[IdentityUserId] IS NOT NULL");

                b.ToTable("Users");
            });
#pragma warning restore 612, 618
        }
    }
}