using Microsoft.EntityFrameworkCore.Migrations;

namespace LiberDent.Data.Migrations
{
    public partial class m51 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoziomUprawnien",
                columns: table => new
                {
                    IdPoziomUprawnien = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerUprawnien = table.Column<int>(nullable: false),
                    OpisUprawnien = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoziomUprawnien", x => x.IdPoziomUprawnien);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoziomUprawnien");
        }
    }
}
