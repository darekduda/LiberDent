using Microsoft.EntityFrameworkCore.Migrations;

namespace LiberDent.Data.Migrations
{
    public partial class m48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CzyOdbyta",
                table: "UmowioneWizyty",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CzyPacjentByl",
                table: "UmowioneWizyty",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CzyOdbyta",
                table: "UmowioneWizyty");

            migrationBuilder.DropColumn(
                name: "CzyPacjentByl",
                table: "UmowioneWizyty");
        }
    }
}
