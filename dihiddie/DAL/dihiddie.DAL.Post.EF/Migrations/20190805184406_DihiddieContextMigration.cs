using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dihiddie.DAL.Post.EF.Migrations
{
    public partial class DihiddieContextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true, defaultValueSql: "(getdate())"),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Content = table.Column<byte[]>(nullable: false),
                    PreviewImagePath = table.Column<string>(unicode: false, maxLength: 260, nullable: false),
                    PreviewText = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    IsBlogPost = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
