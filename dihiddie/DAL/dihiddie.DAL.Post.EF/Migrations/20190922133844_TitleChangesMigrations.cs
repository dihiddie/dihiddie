using Microsoft.EntityFrameworkCore.Migrations;

namespace dihiddie.DAL.Post.EF.Migrations
{
    public partial class TitleChangesMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostContent_PostInformation_PostInformationId",
                table: "PostContent");

            migrationBuilder.DropIndex(
                name: "IX_PostContent_PostInformationId",
                table: "PostContent");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PostInformation");

            migrationBuilder.DropColumn(
                name: "PostInformationId",
                table: "PostContent");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PostContent",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostInformation_PostContent_PostId",
                table: "PostInformation",
                column: "PostId",
                principalTable: "PostContent",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostInformation_PostContent_PostId",
                table: "PostInformation");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PostContent");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PostInformation",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PostInformationId",
                table: "PostContent",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostContent_PostInformationId",
                table: "PostContent",
                column: "PostInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostContent_PostInformation_PostInformationId",
                table: "PostContent",
                column: "PostInformationId",
                principalTable: "PostInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
