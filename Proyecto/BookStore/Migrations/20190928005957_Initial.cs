using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    authorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    surname = table.Column<string>(unicode: false, maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.authorId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    studentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    surname = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    birthdate = table.Column<DateTime>(type: "date", nullable: true),
                    gender = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    @class = table.Column<string>(name: "class", unicode: false, maxLength: 7, nullable: true),
                    point = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    bookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(unicode: false, maxLength: 90, nullable: true),
                    pagecount = table.Column<int>(nullable: true),
                    point = table.Column<int>(nullable: true),
                    authorId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.bookId);
                    table.ForeignKey(
                        name: "FK_books_authors",
                        column: x => x.authorId,
                        principalTable: "Author",
                        principalColumn: "authorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_books_types",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "borrow",
                columns: table => new
                {
                    borrowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    studentId = table.Column<int>(nullable: true),
                    bookId = table.Column<int>(nullable: true),
                    takenDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    broughtDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrow", x => x.borrowId);
                    table.ForeignKey(
                        name: "FK_borrows_books",
                        column: x => x.bookId,
                        principalTable: "Book",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_borrows_students",
                        column: x => x.studentId,
                        principalTable: "student",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Person = table.Column<string>(maxLength: 150, nullable: true),
                    ReviewText = table.Column<string>(maxLength: 500, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    bookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_book",
                        column: x => x.bookId,
                        principalTable: "Book",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_authorId",
                table: "Book",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_borrow_bookId",
                table: "borrow",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_borrow_studentId",
                table: "borrow",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_bookId",
                table: "Review",
                column: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "borrow");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
