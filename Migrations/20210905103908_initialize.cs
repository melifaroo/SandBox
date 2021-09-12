using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SandBox.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "bloggers",
                columns: table => new
                {
                    BloggerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bloggers", x => x.BloggerId);
                });

            migrationBuilder.CreateTable(
                name: "blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "readers",
                columns: table => new
                {
                    ReaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_readers", x => x.ReaderId);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_books_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloggerId = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_posts_bloggers_BloggerId",
                        column: x => x.BloggerId,
                        principalTable: "bloggers",
                        principalColumn: "BloggerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_posts_blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "borrowings",
                columns: table => new
                {
                    BorrowingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReaderId = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    BorrowingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Term = table.Column<int>(type: "int", nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrowings", x => x.BorrowingId);
                    table.ForeignKey(
                        name: "FK_borrowings_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_borrowings_readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "readers",
                        principalColumn: "ReaderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "AuthorId", "FullName" },
                values: new object[,]
                {
                    { 5, "Jules Verne" },
                    { 4, "Lewis Carroll" },
                    { 1, "J.R.R.Tolkien" },
                    { 2, "J.K.Rowling" },
                    { 3, "Agatha Christie" }
                });

            migrationBuilder.InsertData(
                table: "bloggers",
                columns: new[] { "BloggerId", "NickName" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Doe" },
                    { 3, "Anonimous" }
                });

            migrationBuilder.InsertData(
                table: "blogs",
                columns: new[] { "BlogId", "Url" },
                values: new object[,]
                {
                    { 1, "/news" },
                    { 2, "/events" }
                });

            migrationBuilder.InsertData(
                table: "readers",
                columns: new[] { "ReaderId", "FullName" },
                values: new object[,]
                {
                    { 9, "Marlie Whannel" },
                    { 1, "Marja Tinline" },
                    { 2, "Jermaine Brolechan" },
                    { 3, "Olly Yakebowitch" },
                    { 4, "Pu Long" },
                    { 5, "Celestina Beeching" },
                    { 6, "Abner Hyland" },
                    { 7, "Florenza Wensley" },
                    { 8, "Brocky Greenier" },
                    { 10, "Raoul Swyne" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "BookId", "AuthorId", "Title", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, "Lord of the Rings : The Fellowship of the Ring", 2 },
                    { 2, 1, "Lord of the Rings : The Two Towers", 2 },
                    { 3, 1, "Lord of the Rings : The Return of the King", 2 },
                    { 4, 2, "Harry Potter and the Sorcerer's Stone", 2 },
                    { 5, 2, "Harry Potter and the Chamber of Secrets", 2 },
                    { 6, 2, "Harry Potter and the Prisoner of Azkaban", 2 },
                    { 7, 2, "Harry Potter and the Goblet of Fire", 2 },
                    { 8, 3, "And Then There Were None", 2 },
                    { 9, 4, "Alice's Adventures in Wonderland", 3 },
                    { 10, 5, "Twenty Thousand Leagues Under the Sea", 2 },
                    { 11, 5, "In Search of the Castaways", 2 }
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "PostId", "BlogId", "BloggerId", "Content", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "New web app with vue client", "Hooray" },
                    { 2, 2, 1, "EFCore with sql", "DB create" },
                    { 3, 1, 2, "Testng of REST api passed successfullyt", "Congrats!" }
                });

            migrationBuilder.InsertData(
                table: "borrowings",
                columns: new[] { "BorrowingId", "BookId", "BorrowingDate", "ReaderId", "ReturnDate", "Term" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 14 },
                    { 3, 1, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 14 },
                    { 5, 2, new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 14 },
                    { 4, 4, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 28 },
                    { 6, 4, new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 14 },
                    { 1, 5, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 28 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_AuthorId",
                table: "books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_borrowings_BookId",
                table: "borrowings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_borrowings_ReaderId",
                table: "borrowings",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_BloggerId",
                table: "posts",
                column: "BloggerId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_BlogId",
                table: "posts",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "borrowings");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "readers");

            migrationBuilder.DropTable(
                name: "bloggers");

            migrationBuilder.DropTable(
                name: "blogs");

            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
