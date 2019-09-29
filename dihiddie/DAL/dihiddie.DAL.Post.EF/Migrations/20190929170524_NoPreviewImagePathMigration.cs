using Microsoft.EntityFrameworkCore.Migrations;

namespace dihiddie.DAL.Post.EF.Migrations
{
    public partial class NoPreviewImagePathMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviewImagePath",
                table: "PostInformation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PreviewImagePath",
                table: "PostInformation",
                unicode: false,
                maxLength: 260,
                nullable: false,
                defaultValue: "");
        }
    }
}
