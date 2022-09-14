using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StepChange.Blogger.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublisherRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPublishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Publisher = table.Column<string>(maxLength: 20, nullable: false),
                    HashPassword = table.Column<string>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPublishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPublishers_PublisherRoles_Role",
                        column: x => x.Role,
                        principalTable: "PublisherRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    PublisherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_BlogPublishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "BlogPublishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PublisherRoles",
                columns: new[] { "Id", "Description" },
                values: new object[] { 0, "Can create and edit all blog posts." });

            migrationBuilder.InsertData(
                table: "PublisherRoles",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Can create, edit and delete all blog posts." });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_PublisherId",
                table: "BlogPosts",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPublishers_Publisher",
                table: "BlogPublishers",
                column: "Publisher",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPublishers_Role",
                table: "BlogPublishers",
                column: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "BlogPublishers");

            migrationBuilder.DropTable(
                name: "PublisherRoles");
        }
    }
}
