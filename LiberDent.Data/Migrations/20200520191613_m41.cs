using Microsoft.EntityFrameworkCore.Migrations;

namespace LiberDent.Data.Migrations
{
    public partial class m41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTytulNaukowy",
                table: "DaneOPersonelu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TytulNaukowyIdTytulNaukowy",
                table: "DaneOPersonelu",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DaneOPersonelu_TytulNaukowyIdTytulNaukowy",
                table: "DaneOPersonelu",
                column: "TytulNaukowyIdTytulNaukowy");

            migrationBuilder.AddForeignKey(
                name: "FK_DaneOPersonelu_TytulNaukowy_TytulNaukowyIdTytulNaukowy",
                table: "DaneOPersonelu",
                column: "TytulNaukowyIdTytulNaukowy",
                principalTable: "TytulNaukowy",
                principalColumn: "IdTytulNaukowy",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaneOPersonelu_TytulNaukowy_TytulNaukowyIdTytulNaukowy",
                table: "DaneOPersonelu");

            migrationBuilder.DropIndex(
                name: "IX_DaneOPersonelu_TytulNaukowyIdTytulNaukowy",
                table: "DaneOPersonelu");

            migrationBuilder.DropColumn(
                name: "IdTytulNaukowy",
                table: "DaneOPersonelu");

            migrationBuilder.DropColumn(
                name: "TytulNaukowyIdTytulNaukowy",
                table: "DaneOPersonelu");
        }
    }
}
