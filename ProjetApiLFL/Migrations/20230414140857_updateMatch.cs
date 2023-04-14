using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetApiLFL.Migrations
{
    public partial class updateMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlueScore",
                table: "Matchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlueTeamId",
                table: "Matchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedScore",
                table: "Matchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedTeamId",
                table: "Matchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_BlueTeamId",
                table: "Matchs",
                column: "BlueTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_RedTeamId",
                table: "Matchs",
                column: "RedTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matchs_Teams_BlueTeamId",
                table: "Matchs",
                column: "BlueTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matchs_Teams_RedTeamId",
                table: "Matchs",
                column: "RedTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matchs_Teams_BlueTeamId",
                table: "Matchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Matchs_Teams_RedTeamId",
                table: "Matchs");

            migrationBuilder.DropIndex(
                name: "IX_Matchs_BlueTeamId",
                table: "Matchs");

            migrationBuilder.DropIndex(
                name: "IX_Matchs_RedTeamId",
                table: "Matchs");

            migrationBuilder.DropColumn(
                name: "BlueScore",
                table: "Matchs");

            migrationBuilder.DropColumn(
                name: "BlueTeamId",
                table: "Matchs");

            migrationBuilder.DropColumn(
                name: "RedScore",
                table: "Matchs");

            migrationBuilder.DropColumn(
                name: "RedTeamId",
                table: "Matchs");
        }
    }
}
