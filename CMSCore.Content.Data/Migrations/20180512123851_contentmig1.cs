namespace CMSCore.Content.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class contentmig1 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Comments");

            migrationBuilder.DropTable(
                "FeedItems");

            migrationBuilder.DropTable(
                "Feeds");

            migrationBuilder.DropTable(
                "Pages");

            migrationBuilder.DropTable(
                "Tags");

            migrationBuilder.DropTable(
                "Users");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Comments",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_Comments", x => x.Id); });

            migrationBuilder.CreateTable(
                "FeedItems",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_FeedItems", x => x.Id); });

            migrationBuilder.CreateTable(
                "Feeds",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_Feeds", x => x.Id); });

            migrationBuilder.CreateTable(
                "Pages",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_Pages", x => x.Id); });

            migrationBuilder.CreateTable(
                "Tags",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_Tags", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateIndex(
                "IX_Users_IdentityUserId",
                "Users",
                "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");
        }
    }
}