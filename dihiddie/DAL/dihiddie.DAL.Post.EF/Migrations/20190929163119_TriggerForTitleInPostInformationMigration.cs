using Microsoft.EntityFrameworkCore.Migrations;

namespace dihiddie.DAL.Post.EF.Migrations
{
    public partial class TriggerForTitleInPostInformationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER iPostInformationTitle ON PostInformation
                AFTER  INSERT AS 
            BEGIN
                    declare @postContentId int = (select PostId from inserted)
                    declare @postInformationId int = (select Id from inserted)
                    update PostInformation set Title = (select Title from PostContent where Id = @postContentId) where Id = @postInformationId
            END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER iPostInformationTitle");
        }
    }
}
