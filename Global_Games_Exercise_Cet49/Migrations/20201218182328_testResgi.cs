using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Global_Games_Exercise_Cet49.Migrations
{
    public partial class testResgi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "incris");

            migrationBuilder.CreateTable(
                name: "Registos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Sur = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    Local = table.Column<string>(nullable: false),
                    CC = table.Column<string>(nullable: false),
                    Birth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registos");

            migrationBuilder.CreateTable(
                name: "incris",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    Birth = table.Column<DateTime>(nullable: false),
                    CC = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incris", x => x.Id);
                });
        }
    }
}
