using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_ASP_Project.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2262cbe5-9c3b-4dff-b229-a9b8e825b95e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b20b6f5f-ee41-4340-bc2b-54a3098df954");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "dc61d860-2041-4bae-8b38-d806e48783f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1acff28b-8aaf-469d-baf7-6f94245e4d7c", "AQAAAAEAACcQAAAAEBleMkjSc8/oo9mT7axS8ezGdPCUWfjkJB5s/wADkSJ2BcGEP1t+2cqXQqguvZ5RwQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.Publisher_Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9f76b5f3-8a27-4340-ae7f-3cbaeec33f0c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5042ec6d-692a-4413-927f-477e30a455ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "abd67a2a-2071-4827-be32-5a837dc37799");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "070893b1-72ef-479a-8965-84e7a1d4cf9a", "AQAAAAEAACcQAAAAEJhG1i84hGXwMpzEuMiIQBmDflV6JpFqCo6/P9EfSkWEBLboIaOs1R61rL+8XnbklA==" });
        }
    }
}
