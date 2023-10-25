using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.PL.Migrations
{
    public partial class AssignAdminUsertoAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into [security].[UserRoles] (UserId, RoleId) select '3bf5f8b0-c54e-4cf3-97ee-e3fc6d0792e6', Id from [security].[Roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId = '3bf5f8b0-c54e-4cf3-97ee-e3fc6d0792e6'");
        }
    }
}
