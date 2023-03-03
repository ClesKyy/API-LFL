using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetApiLFL.Migrations
{
    public partial class test033 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScoreTotal",
                table: "Teams",
                newName: "Logo");

            migrationBuilder.AddColumn<int>(
                name: "Lose",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Win",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lose",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Win",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Teams",
                newName: "ScoreTotal");
        }
    }
}
