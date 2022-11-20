using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddingPerodToAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocatons",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocatons");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c75edf14-0cf9-471b-81c0-a2bf04d0a630", "AQAAAAEAACcQAAAAEPPCyNNxIhUjf/bftxlFoLddTGafk5CycJI/VldoxYtrITPQzrHG6V++FsjwlfWt4Q==", "a5ca36d1-39e9-47c4-bd55-14d8ef951d24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3656108-9304-4eee-811e-5188debe14c1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dffad1c0-ccce-4107-b3ec-c3869cba6fb3", "AQAAAAEAACcQAAAAEJwryirRcwIkRL4XNyKCXJd6TGiOF5Wmm+DCunZHbN5zZThGK0PogzUj/MI4mZK61A==", "51c6085d-a865-403f-9fae-968519459430" });
        }
    }
}
