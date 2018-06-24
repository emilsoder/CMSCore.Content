using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCore.Content.Data.Migrations
{
    public partial class inital1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ActiveContentVersionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentVersion",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    VersionNumber = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ContentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentVersion_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    FeedEnabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ContentId = table.Column<string>(nullable: true),
                    FeedId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true),
                    ContentId = table.Column<string>(nullable: true),
                    ContentId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Content_ContentId1",
                        column: x => x.ContentId1,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    PageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feeds_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    NormalizedTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    CommentsEnabled = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ContentId = table.Column<string>(nullable: true),
                    FeedId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedItems_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeedItems_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    FeedItemId = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ContentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_FeedItems_FeedItemId",
                        column: x => x.FeedItemId,
                        principalTable: "FeedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    MarkedToDelete = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    FeedItemId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_FeedItems_FeedItemId",
                        column: x => x.FeedItemId,
                        principalTable: "FeedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ContentId",
                table: "Comments",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FeedItemId",
                table: "Comments",
                column: "FeedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentVersion_ContentId",
                table: "ContentVersion",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedItems_ContentId",
                table: "FeedItems",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedItems_FeedId",
                table: "FeedItems",
                column: "FeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_PageId",
                table: "Feeds",
                column: "PageId",
                unique: true,
                filter: "[PageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ContentId",
                table: "Pages",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_FeedItemId",
                table: "Tags",
                column: "FeedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContentId1",
                table: "Users",
                column: "ContentId1");

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
                name: "ContentVersion");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FeedItems");

            migrationBuilder.DropTable(
                name: "Feeds");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Content");
        }
    }
}
