using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiberDent.Data.Migrations
{
    public partial class m47 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RodzajeWizyty",
                columns: table => new
                {
                    IdRodzajeWizyty = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajeWizyty", x => x.IdRodzajeWizyty);
                });

            migrationBuilder.CreateTable(
                name: "UmowioneWizyty",
                columns: table => new
                {
                    IdUmowioneWizyty = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataWizyty = table.Column<DateTime>(nullable: false),
                    GodzinaWizyty = table.Column<TimeSpan>(nullable: false),
                    IdApplicationUser = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    IdLekarza = table.Column<int>(nullable: false),
                    DaneLekarzaIdDaneLekarza = table.Column<int>(nullable: true),
                    IdRodzajeWizyty = table.Column<int>(nullable: false),
                    RodzajeWizytyIdRodzajeWizyty = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UmowioneWizyty", x => x.IdUmowioneWizyty);
                    table.ForeignKey(
                        name: "FK_UmowioneWizyty_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UmowioneWizyty_DaneLekarza_DaneLekarzaIdDaneLekarza",
                        column: x => x.DaneLekarzaIdDaneLekarza,
                        principalTable: "DaneLekarza",
                        principalColumn: "IdDaneLekarza",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UmowioneWizyty_RodzajeWizyty_RodzajeWizytyIdRodzajeWizyty",
                        column: x => x.RodzajeWizytyIdRodzajeWizyty,
                        principalTable: "RodzajeWizyty",
                        principalColumn: "IdRodzajeWizyty",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UmowioneWizyty_ApplicationUserId",
                table: "UmowioneWizyty",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UmowioneWizyty_DaneLekarzaIdDaneLekarza",
                table: "UmowioneWizyty",
                column: "DaneLekarzaIdDaneLekarza");

            migrationBuilder.CreateIndex(
                name: "IX_UmowioneWizyty_RodzajeWizytyIdRodzajeWizyty",
                table: "UmowioneWizyty",
                column: "RodzajeWizytyIdRodzajeWizyty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UmowioneWizyty");

            migrationBuilder.DropTable(
                name: "RodzajeWizyty");
        }
    }
}
