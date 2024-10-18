using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyApi.Migrations
{
    public partial class BlogPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blog");

            migrationBuilder.RenameTable(
                name: "BlogUsers",
                newName: "BlogUsers",
                newSchema: "blog");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                schema: "blog",
                table: "BlogUsers",
                newName: "Password");

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                schema: "blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    BlogUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_BlogUsers_BlogUserId",
                        column: x => x.BlogUserId,
                        principalSchema: "blog",
                        principalTable: "BlogUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_BlogUserId",
                schema: "blog",
                table: "BlogPosts",
                column: "BlogUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts",
                schema: "blog");

            migrationBuilder.RenameTable(
                name: "BlogUsers",
                schema: "blog",
                newName: "BlogUsers");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "BlogUsers",
                newName: "PasswordHash");
        }
    }
}
