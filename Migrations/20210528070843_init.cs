using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jhoncedricromano.window.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<Guid>(nullable: false),
                    bktitle = table.Column<string>(nullable: true),
                    bkauthor = table.Column<string>(nullable: true),
                    bkpublisher = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<Guid>(nullable: false),
                    studentname = table.Column<string>(nullable: true),
                    studentage = table.Column<string>(nullable: true),
                    studentcourse = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "bkauthor", "bkpublisher", "bktitle" },
                values: new object[] { new Guid("1957baaa-ff27-47b6-9acc-8e907ef6c4bb"), "Ken Folett", "ewan", "Fall of Giants" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "bkauthor", "bkpublisher", "bktitle" },
                values: new object[] { new Guid("d44a592d-8860-497d-9154-3e82119ec464"), "sam frost", "ewan", "The Hidden Maid" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "bkauthor", "bkpublisher", "bktitle" },
                values: new object[] { new Guid("3d2863e5-d33f-40c0-ac76-879668da8cef"), "Arthur Blake", "ewan", "Lust Royale" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
