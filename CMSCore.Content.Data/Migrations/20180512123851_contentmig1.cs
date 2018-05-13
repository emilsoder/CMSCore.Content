﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCore.Content.Data.Migrations
{
    public partial class contentmig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EntityId = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    IsActiveVersion = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    FeedItemId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EntityId = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    IsActiveVersion = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    FeedId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    NormalizedTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CommentsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EntityId = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    IsActiveVersion = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    PageId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EntityId = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    IsActiveVersion = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    FeedEnabled = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EntityId = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    IsActiveVersion = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    FeedItemId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EntityId = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    IsActiveVersion = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdentityUserId",
                table: "Users",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FeedItems");

            migrationBuilder.DropTable(
                name: "Feeds");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}