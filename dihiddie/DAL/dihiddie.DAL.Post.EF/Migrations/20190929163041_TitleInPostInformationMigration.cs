using Microsoft.EntityFrameworkCore.Migrations;

namespace dihiddie.DAL.Post.EF.Migrations
{
    public partial class TitleInPostInformationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PostInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "PostInformation");
        }
    }
}
