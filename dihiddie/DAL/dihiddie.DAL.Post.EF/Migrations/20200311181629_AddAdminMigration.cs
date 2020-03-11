using dihiddie.Utils.PasswordHasher;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dihiddie.DAL.Post.EF.Migrations
{
    public partial class AddAdminMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO [dbo].[User] (Name, Password) VALUES ('admin', '{PasswordHash.HashPassword("admin")}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
