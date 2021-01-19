using Microsoft.EntityFrameworkCore.Migrations;

namespace Global_Games_Exercise_Cet49.Migrations
{
    public partial class GetBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Registos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Registos",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Registos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Registos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
