using Microsoft.EntityFrameworkCore.Migrations;

namespace LiberDent.Data.Migrations
{
    public partial class m42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdStanowiska",
                table: "DaneOPersonelu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StanowiskaIdStanowiska",
                table: "DaneOPersonelu",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stanowiska",
                columns: table => new
                {
                    IdStanowiska = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanowiska", x => x.IdStanowiska);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaneOPersonelu_StanowiskaIdStanowiska",
                table: "DaneOPersonelu",
                column: "StanowiskaIdStanowiska");

            migrationBuilder.AddForeignKey(
                name: "FK_DaneOPersonelu_Stanowiska_StanowiskaIdStanowiska",
                table: "DaneOPersonelu",
                column: "StanowiskaIdStanowiska",
                principalTable: "Stanowiska",
                principalColumn: "IdStanowiska",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaneOPersonelu_Stanowiska_StanowiskaIdStanowiska",
                table: "DaneOPersonelu");

            migrationBuilder.DropTable(
                name: "Stanowiska");

            migrationBuilder.DropIndex(
                name: "IX_DaneOPersonelu_StanowiskaIdStanowiska",
                table: "DaneOPersonelu");

            migrationBuilder.DropColumn(
                name: "IdStanowiska",
                table: "DaneOPersonelu");

            migrationBuilder.DropColumn(
                name: "StanowiskaIdStanowiska",
                table: "DaneOPersonelu");
        }
    }
}
