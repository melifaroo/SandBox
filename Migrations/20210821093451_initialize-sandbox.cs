using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordsApp.Migrations
{
    public partial class initializesandbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Bloggers",
                columns: table => new
                {
                    BloggerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloggers", x => x.BloggerId);
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
                name: "Readers",
                columns: table => new
                {
                    ReaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.ReaderId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
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
                    BloggerId = table.Column<int>(type: "int", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_posts_Bloggers_BloggerId",
                        column: x => x.BloggerId,
                        principalTable: "Bloggers",
                        principalColumn: "BloggerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_posts_blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Borrowings",
                columns: table => new
                {
                    BorrowingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReaderId = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowings", x => x.BorrowingId);
                    table.ForeignKey(
                        name: "FK_Borrowings_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Borrowings_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "ReaderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FullName" },
                values: new object[,]
                {
                    { 5, "Jules Verne" },
                    { 1, "J.R.R.Tolkien" },
                    { 2, "J.K.Rowling" },
                    { 3, "Agatha Christie" },
                    { 4, "Lewis Carroll" }
                });

            migrationBuilder.InsertData(
                table: "Bloggers",
                columns: new[] { "BloggerId", "NickName" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Doe" },
                    { 3, "Anonimous" }
                });

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "ReaderId", "FullName" },
                values: new object[,]
                {
                    { 8, "Brocky Greenier" },
                    { 7, "Florenza Wensley" },
                    { 6, "Abner Hyland" },
                    { 5, "Celestina Beeching" },
                    { 4, "Pu Long" },
                    { 10, "Raoul Swyne" },
                    { 2, "Jermaine Brolechan" },
                    { 1, "Marja Tinline" },
                    { 9, "Marlie Whannel" },
                    { 3, "Olly Yakebowitch" }
                });

            migrationBuilder.InsertData(
                table: "blogs",
                columns: new[] { "BlogId", "Url" },
                values: new object[,]
                {
                    { 2, "/events" },
                    { 1, "/news" }
                });

            migrationBuilder.InsertData(
                table: "Books",
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
                table: "Borrowings",
                columns: new[] { "BorrowingId", "BookId", "Date", "ReaderId", "Term" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 14 },
                    { 3, 1, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 14 },
                    { 5, 2, new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 14 },
                    { 4, 4, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 28 },
                    { 6, 4, new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 14 },
                    { 1, 5, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 28 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_BookId",
                table: "Borrowings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_ReaderId",
                table: "Borrowings",
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
                name: "Borrowings");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "Bloggers");

            migrationBuilder.DropTable(
                name: "blogs");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
