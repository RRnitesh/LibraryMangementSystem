using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initalUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    img_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "librarians",
                columns: table => new
                {
                    LibrarianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_librarians", x => x.LibrarianId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "BookRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_BookRequests_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedBooks",
                columns: table => new
                {
                    BorrowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedBooks", x => x.BorrowId);
                    table.ForeignKey(
                        name: "FK_BorrowedBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Genre", "ISBN", "Quantity", "Title", "img_url" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "Fiction", "9780743273565", 5, "The Great Gatsby", "images/Books/the-great-gatsby.jpg" },
                    { 2, "George Orwell", "Dystopian", "9780451524935", 10, "1984", "images/Books/1984.jpg" },
                    { 3, "Harper Lee", "Fiction", "9780061120084", 8, "To Kill a Mockingbird", "images/Books/to-kill-a-mockingbird.jpg" },
                    { 4, "Jane Austen", "Romance", "9780141439518", 3, "Pride and Prejudice", "images/Books/pride-and-prejudice.jpg" },
                    { 5, "Herman Melville", "Adventure", "9781503280786", 7, "Moby Dick", "images/Books/moby-dick.jpg" },
                    { 6, "J.D. Salinger", "Fiction", "9780316769488", 4, "The Catcher in the Rye", "images/Books/the-catcher-in-the- rey.jpg" },
                    { 7, "Aldous Huxley", "Dystopian", "9780060850524", 6, "Brave New World", "images/Books/brave-new-world.jpg" },
                    { 8, "Fyodor Dostoevsky", "Philosophy", "9780486415871", 3, "Crime and Punishment", "images/Books/crime-and-punishment.jpeg" },
                    { 9, "Leo Tolstoy", "Historical", "9780140447934", 5, "War and Peace", "images/Books/war-and-peace.jpg" },
                    { 10, "Homer", "Epic", "9780140268867", 2, "The Odyssey", "images/Books/odysessy.jpg" },
                    { 11, "J.R.R. Tolkien", "Fantasy", "9780345339683", 9, "The Hobbit", "images/Books/the-hobit.jpg" },
                    { 12, "J.R.R. Tolkien", "Fantasy", "9780618640157", 10, "The Lord of the Rings", "images/Books/the-lord-of-the-rings.jpg" },
                    { 13, "Ray Bradbury", "Dystopian", "9781451673319", 6, "Fahrenheit 451", "images/Books/Fahrenheit451.jpg" },
                    { 14, "Oscar Wilde", "Philosophical", "9780141439570", 4, "The Picture of Dorian Gray", "images/Books/the-picture-of-dorian-gray.jpg" }
                });

            migrationBuilder.InsertData(
                table: "librarians",
                columns: new[] { "LibrarianId", "Email", "PasswordHash", "Username" },
                values: new object[] { 1, "niteshrestha00@gmail.com", "12345", "Nitesh Shrestha" });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_BookId",
                table: "BookRequests",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_BookId",
                table: "BorrowedBooks",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRequests");

            migrationBuilder.DropTable(
                name: "BorrowedBooks");

            migrationBuilder.DropTable(
                name: "librarians");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
