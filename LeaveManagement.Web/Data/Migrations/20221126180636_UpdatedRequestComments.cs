using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class UpdatedRequestComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3656108-9304-4efe-811e-5188debe14c1",
                column: "ConcurrencyStamp",
                value: "1d90983d-2a49-4f09-a680-d969ef344015");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3856108-9304-4eaa-811e-5188dafe14c1",
                column: "ConcurrencyStamp",
                value: "17b83658-77e8-4faa-9bae-53dafa124cc9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6689f13c-16b7-490d-8081-0002f7759d26",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "629fb98a-a14b-46e5-b556-3302e9b84800", "AQAAAAEAACcQAAAAEDjSofSPSlf8EU3+FHl2BffQPMmOBJUEaRIYu3ZzKRXshoxaWfSd48T3b7H3124gtA==", "2b24018d-0de1-4b14-99ab-e9f8720ffa15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3656108-9304-4eee-811e-5188debe14c1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "308cd485-91aa-4e53-9d11-80c11ca03db6", "AQAAAAEAACcQAAAAEPaH7yfWiQF/1KuUNX7dMIP1AjPCyhfO1m/gB/Cn+nHLXChd5morkyouD3aE8+IxUw==", "47562789-9251-46f2-b850-106391cbfae9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3656108-9304-4efe-811e-5188debe14c1",
                column: "ConcurrencyStamp",
                value: "278e6e2a-bddf-4cd8-be03-2a2692748f5d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3856108-9304-4eaa-811e-5188dafe14c1",
                column: "ConcurrencyStamp",
                value: "6425740d-7807-4dce-a612-053fbfc539dc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6689f13c-16b7-490d-8081-0002f7759d26",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dd88ce1-b6cc-43b5-a59b-d0efcc7d1af0", "AQAAAAEAACcQAAAAEKCyZioP4rUT6XkT7cjtUkTAkfaChzRq18NSFa0OEMfUnZa3tb/W8230X6ef6ZE9Xw==", "e56f03f6-2c3c-416e-a548-dbf5947bc9e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3656108-9304-4eee-811e-5188debe14c1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "889d3369-95d9-4671-b5ff-d780625af467", "AQAAAAEAACcQAAAAEH++4RCXxhbiJmQIx4qPikUdmePB9BRDb1Vr/ZOe0lkDWs6e2wmY/vOgBlgxPBMGAg==", "acd8a12c-2f79-4000-a363-414a9bfab2dd" });
        }
    }
}
