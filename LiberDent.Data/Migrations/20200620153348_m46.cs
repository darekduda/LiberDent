using Microsoft.EntityFrameworkCore.Migrations;

namespace LiberDent.Data.Migrations
{
    public partial class m46 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CzyLekarz",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DaneLekarza",
                columns: table => new
                {
                    IdDaneLekarza = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true),
                    IdTytulNaukowy = table.Column<int>(nullable: false),
                    TytulNaukowyIdTytulNaukowy = table.Column<int>(nullable: true),
                    IdStanowiska = table.Column<int>(nullable: false),
                    StanowiskaIdStanowiska = table.Column<int>(nullable: true),
                    PoziomUprawnien = table.Column<int>(nullable: false),
                    IdUzytkownika = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaneLekarza", x => x.IdDaneLekarza);
                    table.ForeignKey(
                        name: "FK_DaneLekarza_AspNetUsers_IdUzytkownika",
                        column: x => x.IdUzytkownika,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DaneLekarza_Stanowiska_StanowiskaIdStanowiska",
                        column: x => x.StanowiskaIdStanowiska,
                        principalTable: "Stanowiska",
                        principalColumn: "IdStanowiska",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DaneLekarza_TytulNaukowy_TytulNaukowyIdTytulNaukowy",
                        column: x => x.TytulNaukowyIdTytulNaukowy,
                        principalTable: "TytulNaukowy",
                        principalColumn: "IdTytulNaukowy",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaneLekarza_IdUzytkownika",
                table: "DaneLekarza",
                column: "IdUzytkownika",
                unique: true,
                filter: "[IdUzytkownika] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DaneLekarza_StanowiskaIdStanowiska",
                table: "DaneLekarza",
                column: "StanowiskaIdStanowiska");

            migrationBuilder.CreateIndex(
                name: "IX_DaneLekarza_TytulNaukowyIdTytulNaukowy",
                table: "DaneLekarza",
                column: "TytulNaukowyIdTytulNaukowy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaneLekarza");

            migrationBuilder.DropColumn(
                name: "CzyLekarz",
                table: "AspNetUsers");
        }
    }
}
