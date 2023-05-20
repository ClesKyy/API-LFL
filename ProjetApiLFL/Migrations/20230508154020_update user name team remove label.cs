using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetApiLFL.Migrations
{
    public partial class updateusernameteamremovelabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "Pseudo",
                table: "AspNetUsers",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "Pseudo");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
