using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecijalnaTabela",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Osobine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PodrucjeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecijalnaTabela", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpecijalnaTabela_Podrucje_PodrucjeID",
                        column: x => x.PodrucjeID,
                        principalTable: "Podrucje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecijalnaTabela_PodrucjeID",
                table: "SpecijalnaTabela",
                column: "PodrucjeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecijalnaTabela");
        }
    }
}
