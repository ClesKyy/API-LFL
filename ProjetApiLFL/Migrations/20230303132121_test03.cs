using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetApiLFL.Migrations
{
    public partial class test03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImg",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImg",
                table: "Players");
        }
    }
}
