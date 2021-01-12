using Microsoft.EntityFrameworkCore.Migrations;

namespace Global_Games_Exercise_Cet49.Migrations
{
    public partial class MrrFx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Registos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Registos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Newls",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Registos");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Registos");

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Newls",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
