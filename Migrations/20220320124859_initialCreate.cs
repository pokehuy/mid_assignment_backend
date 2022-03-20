using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mid_assignment_backend.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestByUserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProcessedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequest_User_ProcessedByUserId",
                        column: x => x.ProcessedByUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequest_User_RequestByUserId",
                        column: x => x.RequestByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequestDetails",
                columns: table => new
                {
                    BookBorrowingRequestId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequestDetails", x => new { x.BookBorrowingRequestId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetails_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetails_BookBorrowingRequest_BookBorrowingRequestId",
                        column: x => x.BookBorrowingRequestId,
                        principalTable: "BookBorrowingRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Category1" },
                    { 2, "Category2" },
                    { 3, "Category3" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "admin", "Admin", "admin" },
                    { 2, "1", "User", "user1" },
                    { 3, "2", "User", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "CategoryId", "Title" },
                values: new object[,]
                {
                    { 1, "Author1", 1, "Book1" },
                    { 2, "Author2", 2, "Book2" },
                    { 3, "Author3", 3, "Book3" },
                    { 4, "Author3", 3, "Book4" },
                    { 5, "Author1", 3, "Book5" },
                    { 6, "Author6", 3, "Book6" }
                });

            migrationBuilder.InsertData(
                table: "BookBorrowingRequest",
                columns: new[] { "Id", "Date", "ProcessedByUserId", "RequestByUserId", "Status" },
                values: new object[] { 1, new DateTime(2022, 3, 20, 19, 48, 59, 502, DateTimeKind.Local).AddTicks(9760), 1, 3, 0 });

            migrationBuilder.InsertData(
                table: "BookBorrowingRequestDetails",
                columns: new[] { "BookBorrowingRequestId", "BookId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "BookBorrowingRequestDetails",
                columns: new[] { "BookBorrowingRequestId", "BookId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "BookBorrowingRequestDetails",
                columns: new[] { "BookBorrowingRequestId", "BookId" },
                values: new object[] { 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequest_ProcessedByUserId",
                table: "BookBorrowingRequest",
                column: "ProcessedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequest_RequestByUserId",
                table: "BookBorrowingRequest",
                column: "RequestByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequestDetails_BookId",
                table: "BookBorrowingRequestDetails",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrowingRequestDetails");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "BookBorrowingRequest");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
