using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class PopulateMembershipTypeNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE dbo.MembershipTypes SET Name = 'Pay As You Go' where id=1");
            migrationBuilder.Sql("UPDATE dbo.MembershipTypes SET Name = 'Monthly' where id=2");
            migrationBuilder.Sql("UPDATE dbo.MembershipTypes SET Name = 'Quarterly' where id=3");
            migrationBuilder.Sql("UPDATE dbo.MembershipTypes SET Name = 'Annual' where id=4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
