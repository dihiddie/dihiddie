using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dihiddie.DAL.Post.EF.Migrations
{
    public partial class IsDraftFieldAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostContent",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostContent", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 155, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreviewImagePath = table.Column<string>(unicode: false, maxLength: 260, nullable: false),
                    PreviewText = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    IsBlogPost = table.Column<bool>(nullable: true),
                    IsDraft = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PostInfor__PostI__656C112C",
                        column: x => x.PostId,
                        principalTable: "PostContent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagPostLink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TagId = table.Column<int>(nullable: false),
                    PostInformationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagPostLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK__TagPostLi__PostI__6B24EA82",
                        column: x => x.PostInformationId,
                        principalTable: "PostInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TagPostLi__TagId__6A30C649",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__PostInfo__AA126019461B8588",
                table: "PostInformation",
                column: "PostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagPostLink_PostInformationId",
                table: "TagPostLink",
                column: "PostInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_TagPostLink_TagId",
                table: "TagPostLink",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagPostLink");

            migrationBuilder.DropTable(
                name: "PostInformation");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "PostContent");
        }
    }
}
