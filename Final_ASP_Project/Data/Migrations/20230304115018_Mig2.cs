using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_ASP_Project.Data.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_genre_Id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Books_BookId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Books_BookId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "genres");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "books");

            migrationBuilder.RenameColumn(
                name: "book_Price",
                table: "books",
                newName: "Book_Price");

            migrationBuilder.RenameColumn(
                name: "book_ImagURL",
                table: "books",
                newName: "book_urlImage");

            migrationBuilder.RenameIndex(
                name: "IX_Books_genre_Id",
                table: "books",
                newName: "IX_books_genre_Id");

            migrationBuilder.AlterColumn<string>(
                name: "genre_Status",
                table: "genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Book_Price",
                table: "books",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "book_Author",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "book_Publisher",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genres",
                table: "genres",
                column: "genre_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "book_Id");

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publisher_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hotline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher_Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                value: "775ab459-a0f0-4163-bb4a-02fea5a251a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2b88b08e-cc9d-4f4d-a833-74ca53dd146d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "847eac9e-87e5-4f17-99ac-d83e18f54aa4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f867baea-05cf-4b2d-a350-8d3e75a5e733", "AQAAAAEAACcQAAAAEKtFO4SXDhFrOQcrJvPgeJtcw5FTUlHzMLrMC6hfIRls+rnuKbYfqreNYr8lm6fUnQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_books_genres_genre_Id",
                table: "books",
                column: "genre_Id",
                principalTable: "genres",
                principalColumn: "genre_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_books_BookId",
                table: "Carts",
                column: "BookId",
                principalTable: "books",
                principalColumn: "book_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_books_BookId",
                table: "OrderDetails",
                column: "BookId",
                principalTable: "books",
                principalColumn: "book_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_genres_genre_Id",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_books_BookId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_books_BookId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genres",
                table: "genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.DropColumn(
                name: "book_Author",
                table: "books");

            migrationBuilder.DropColumn(
                name: "book_Publisher",
                table: "books");

            migrationBuilder.RenameTable(
                name: "genres",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "Books");

            migrationBuilder.RenameColumn(
                name: "Book_Price",
                table: "Books",
                newName: "book_Price");

            migrationBuilder.RenameColumn(
                name: "book_urlImage",
                table: "Books",
                newName: "book_ImagURL");

            migrationBuilder.RenameIndex(
                name: "IX_books_genre_Id",
                table: "Books",
                newName: "IX_Books_genre_Id");

            migrationBuilder.AlterColumn<string>(
                name: "genre_Status",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "book_Price",
                table: "Books",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "genre_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "book_Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_genre_Id",
                table: "Books",
                column: "genre_Id",
                principalTable: "Genres",
                principalColumn: "genre_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Books_BookId",
                table: "Carts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "book_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Books_BookId",
                table: "OrderDetails",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "book_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
