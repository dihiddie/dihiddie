using Microsoft.EntityFrameworkCore.Migrations;

namespace dihiddie.DAL.Post.EF.Migrations
{
    public partial class PostContentChangesMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__PostInfor__PostI__656C112C",
                table: "PostInformation");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostContent_PostInformation_PostInformationId",
                table: "PostContent");

            migrationBuilder.DropIndex(
                name: "IX_PostContent_PostInformationId",
                table: "PostContent");

            migrationBuilder.DropColumn(
                name: "PostInformationId",
                table: "PostContent");

            migrationBuilder.AddForeignKey(
                name: "FK__PostInfor__PostI__656C112C",
                table: "PostInformation",
                column: "PostId",
                principalTable: "PostContent",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
