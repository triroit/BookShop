using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShop_BookApi.Migrations
{
    /// <inheritdoc />
    public partial class AddBooksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coverUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    addDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "addDate", "author", "coverUrl", "description", "genre", "language", "price", "stock", "title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 15, 15, 35, 19, 98, DateTimeKind.Local).AddTicks(4450), "F. Scott Fitzgerald", "https://example.com/greatgatsby.jpg", "A novel set in the Roaring Twenties, exploring themes of wealth, excess, and the American dream.", "Classic", "English", 100m, 50, "The Great Gatsby" },
                    { 2, new DateTime(2024, 8, 15, 15, 35, 19, 98, DateTimeKind.Local).AddTicks(4464), "Harper Lee", "https://example.com/tokillamockingbird.jpg", "A novel about the serious issues of rape and racial inequality, told through the eyes of a young girl.", "Classic", "English", 300m, 30, "To Kill a Mockingbird" },
                    { 3, new DateTime(2024, 8, 15, 15, 35, 19, 98, DateTimeKind.Local).AddTicks(4467), "George Orwell", "https://example.com/1984.jpg", "A dystopian novel set in a totalitarian society under constant surveillance.", "Dystopian", "English", 200m, 40, "1984" },
                    { 4, new DateTime(2024, 8, 15, 15, 35, 19, 98, DateTimeKind.Local).AddTicks(4469), "Jane Austen", "https://example.com/prideandprejudice.jpg", "A romantic novel that also critiques the British landed gentry at the end of the 18th century.", "Romance", "English", 300m, 20, "Pride and Prejudice" },
                    { 5, new DateTime(2024, 8, 15, 15, 35, 19, 98, DateTimeKind.Local).AddTicks(4471), "J.D. Salinger", "https://example.com/catcherintherye.jpg", "A novel about teenage rebellion and angst, narrated by the iconic character Holden Caulfield.", "Classic", "English", 100m, 25, "The Catcher in the Rye" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
