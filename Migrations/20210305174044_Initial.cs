﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment5_Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Author_First = table.Column<string>(nullable: false),
                    Author_Last = table.Column<string>(nullable: false),
                    Publisher = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: false),
                    Classification = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Page = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}