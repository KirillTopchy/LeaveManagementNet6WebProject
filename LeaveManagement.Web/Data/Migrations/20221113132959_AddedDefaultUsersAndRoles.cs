using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3656108-9304-4efe-811e-5188debe14c1", "7269ba2d-fe1b-4e01-ad52-972f9b5e407d", "Administrator", "ADMINISTRATOR" },
                    { "d3856108-9304-4eaa-811e-5188dafe14c1", "73c42468-3b09-498e-be20-caaa8ead81cd", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6689f13c-16b7-490d-8081-0002f7759d26", 0, "81474e8c-8f20-440f-aa79-f144e462f3aa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", false, "System", "User", false, null, "USER@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAENKP4fauYFIE5egRPt2EaoSqiIap8771yKy0CDOfS4pmisAkTBIXYHVf8rqOjOp+ww==", null, false, "4ee67b89-8e87-4ab1-9f20-8a68645a49d5", null, false, null },
                    { "d3656108-9304-4eee-811e-5188debe14c1", 0, "7cc8e5de-c9f5-4485-96bc-6e9f983e55b3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@test.com", false, "Admin", "Test", false, null, "ADMIN@TEST.COM", null, "AQAAAAEAACcQAAAAEGxVLU1HZb8rqu+o1zDn3nAjg6Fqky54tYkqHVt+wg5+bgZIQWKLMdBXWGDEuuWWfg==", null, false, "fef87f5f-e491-42f0-abc4-5e46a7540247", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d3856108-9304-4eaa-811e-5188dafe14c1", "6689f13c-16b7-490d-8081-0002f7759d26" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a3656108-9304-4efe-811e-5188debe14c1", "d3656108-9304-4eee-811e-5188debe14c1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d3856108-9304-4eaa-811e-5188dafe14c1", "6689f13c-16b7-490d-8081-0002f7759d26" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3656108-9304-4efe-811e-5188debe14c1", "d3656108-9304-4eee-811e-5188debe14c1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3656108-9304-4efe-811e-5188debe14c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3856108-9304-4eaa-811e-5188dafe14c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6689f13c-16b7-490d-8081-0002f7759d26");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3656108-9304-4eee-811e-5188debe14c1");
        }
    }
}
