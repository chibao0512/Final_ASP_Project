using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_ASP_Project.Data.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b5d230c8-3a68-428a-b06c-339a03e62b2b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "782a8ba3-241d-4390-b532-d418a21bac04");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2e8f677c-00ff-4c7b-943e-eee0c968f8d5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e179dea-31d2-4dc7-ab8b-18de842495e0", "AQAAAAEAACcQAAAAEN6Gw+2xahQogauDtGRlGBv1xVN0DGIWGpE5X4t4iWV8t7dsbxmvF7Ujr2jUUVUEzw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6274dc29-20f7-4607-84df-2a003b75010e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "65b3955b-220e-43db-b490-5041561f6dc5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "66a75080-033f-481c-8f70-84451e5bba3b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33932896-92d7-4c38-9fd3-ae54dc3da956", "AQAAAAEAACcQAAAAEBNBlD/XdKQ4Z44TfJaA5sUCA6aaXS3Gi22i0QqMV26XuQuBEojTuF9rXTdjTBEX/Q==" });
        }
    }
}
