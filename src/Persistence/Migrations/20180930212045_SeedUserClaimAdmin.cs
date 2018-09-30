using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedUserClaimAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ef1c42c3-59e7-42bb-8792-049784f8bd71', N'admin@viflix.gr', N'ADMIN@VIFLIX.GR', N'admin@viflix.gr', N'ADMIN@VIFLIX.GR', 0, N'AQAAAAEAACcQAAAAEFOWLl0DxIaki+DFxA6J/YvO+8pX1qbSvrcF4Ym8zqaY2wjouQqnuT0Qnvdzzz8j8A==', N'Z54KDBF6PRY5F543HT4L7OYZYJ5YIKA4', N'464629ec-c539-4bf6-ac1e-a23511fdcdf4', NULL, 0, 0, NULL, 1, 0)");
            migrationBuilder.Sql(@"SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'ef1c42c3-59e7-42bb-8792-049784f8bd71', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'admin')
                SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
