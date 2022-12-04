using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Canceled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3656108-9304-4efe-811e-5188debe14c1",
                column: "ConcurrencyStamp",
                value: "fdcacbac-4d09-410d-b039-b3f28cd3ab25");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3856108-9304-4eaa-811e-5188dafe14c1",
                column: "ConcurrencyStamp",
                value: "933877c2-f246-4613-b71a-218fb8a8c00f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6689f13c-16b7-490d-8081-0002f7759d26",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62744aae-f94f-4598-9dc2-2d25697a258a", "AQAAAAEAACcQAAAAEP5yZhv6EFgh1qOUftrwhA2kDAueqcMXwV8AcZQkH4RaDGMGQu6MGMee/Tp3TRAeDA==", "a9103c1d-f6d0-4a4c-972b-65a32e0cfa55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3656108-9304-4eee-811e-5188debe14c1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9edd2c46-8b43-4932-9db7-6c0dd7127dfb", "AQAAAAEAACcQAAAAEEHZvTLvqryHgbrRjfOwUx6dmSwYIFFcXvVcFr9jiz1xkx2g1ksAMvLcRxHZ6CYWPA==", "24ab574d-861b-4c82-8042-1eb37327d084" });
        }
    }
}
