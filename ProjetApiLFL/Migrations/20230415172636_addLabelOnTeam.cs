using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetApiLFL.Migrations
{
    public partial class addLabelOnTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Teams");
        }
    }
}
