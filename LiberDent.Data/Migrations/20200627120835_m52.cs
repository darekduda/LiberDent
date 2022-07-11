using Microsoft.EntityFrameworkCore.Migrations;

namespace LiberDent.Data.Migrations
{
    public partial class m52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PoziomUprawnien",
                table: "DaneLekarza");

            migrationBuilder.AddColumn<int>(
                name: "IdPoziomUprawnien",
                table: "DaneLekarza",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PoziomUprawnienIdPoziomUprawnien",
                table: "DaneLekarza",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DaneLekarza_PoziomUprawnienIdPoziomUprawnien",
                table: "DaneLekarza",
                column: "PoziomUprawnienIdPoziomUprawnien");

            migrationBuilder.AddForeignKey(
                name: "FK_DaneLekarza_PoziomUprawnien_PoziomUprawnienIdPoziomUprawnien",
                table: "DaneLekarza",
                column: "PoziomUprawnienIdPoziomUprawnien",
                principalTable: "PoziomUprawnien",
                principalColumn: "IdPoziomUprawnien",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaneLekarza_PoziomUprawnien_PoziomUprawnienIdPoziomUprawnien",
                table: "DaneLekarza");

            migrationBuilder.DropIndex(
                name: "IX_DaneLekarza_PoziomUprawnienIdPoziomUprawnien",
                table: "DaneLekarza");

            migrationBuilder.DropColumn(
                name: "IdPoziomUprawnien",
                table: "DaneLekarza");

            migrationBuilder.DropColumn(
                name: "PoziomUprawnienIdPoziomUprawnien",
                table: "DaneLekarza");

            migrationBuilder.AddColumn<int>(
                name: "PoziomUprawnien",
                table: "DaneLekarza",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
