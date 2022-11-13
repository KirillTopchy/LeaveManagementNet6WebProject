using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUsersUsernames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3656108-9304-4efe-811e-5188debe14c1",
                column: "ConcurrencyStamp",
                value: "c5feccf1-061d-4e51-b1ce-a10b40146227");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3856108-9304-4eaa-811e-5188dafe14c1",
                column: "ConcurrencyStamp",
                value: "b07cf2c0-2d07-4cfe-9eb9-0721b7eb9310");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6689f13c-16b7-490d-8081-0002f7759d26",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c75edf14-0cf9-471b-81c0-a2bf04d0a630", true, "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEPPCyNNxIhUjf/bftxlFoLddTGafk5CycJI/VldoxYtrITPQzrHG6V++FsjwlfWt4Q==", "a5ca36d1-39e9-47c4-bd55-14d8ef951d24", "user@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3656108-9304-4eee-811e-5188debe14c1",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "dffad1c0-ccce-4107-b3ec-c3869cba6fb3", true, "ADMIN@TEST.COM", "AQAAAAEAACcQAAAAEJwryirRcwIkRL4XNyKCXJd6TGiOF5Wmm+DCunZHbN5zZThGK0PogzUj/MI4mZK61A==", "51c6085d-a865-403f-9fae-968519459430", "admin@test.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3656108-9304-4efe-811e-5188debe14c1",
                column: "ConcurrencyStamp",
                value: "7269ba2d-fe1b-4e01-ad52-972f9b5e407d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3856108-9304-4eaa-811e-5188dafe14c1",
                column: "ConcurrencyStamp",
                value: "73c42468-3b09-498e-be20-caaa8ead81cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6689f13c-16b7-490d-8081-0002f7759d26",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "81474e8c-8f20-440f-aa79-f144e462f3aa", false, null, "AQAAAAEAACcQAAAAENKP4fauYFIE5egRPt2EaoSqiIap8771yKy0CDOfS4pmisAkTBIXYHVf8rqOjOp+ww==", "4ee67b89-8e87-4ab1-9f20-8a68645a49d5", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3656108-9304-4eee-811e-5188debe14c1",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "7cc8e5de-c9f5-4485-96bc-6e9f983e55b3", false, null, "AQAAAAEAACcQAAAAEGxVLU1HZb8rqu+o1zDn3nAjg6Fqky54tYkqHVt+wg5+bgZIQWKLMdBXWGDEuuWWfg==", "fef87f5f-e491-42f0-abc4-5e46a7540247", null });
        }
    }
}
