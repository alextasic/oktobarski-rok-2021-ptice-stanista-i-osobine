using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Osobina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Vrednost = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Podrucje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podrucje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ptica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    URLSlike = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ptica", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OsobinaPtica",
                columns: table => new
                {
                    OsobineID = table.Column<int>(type: "int", nullable: false),
                    PticeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsobinaPtica", x => new { x.OsobineID, x.PticeID });
                    table.ForeignKey(
                        name: "FK_OsobinaPtica_Osobina_OsobineID",
                        column: x => x.OsobineID,
                        principalTable: "Osobina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OsobinaPtica_Ptica_PticeID",
                        column: x => x.PticeID,
                        principalTable: "Ptica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PticaPodrucje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VidjenaPuta = table.Column<int>(type: "int", nullable: false),
                    PticaID = table.Column<int>(type: "int", nullable: true),
                    PodrucjeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PticaPodrucje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PticaPodrucje_Podrucje_PodrucjeID",
                        column: x => x.PodrucjeID,
                        principalTable: "Podrucje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PticaPodrucje_Ptica_PticaID",
                        column: x => x.PticaID,
                        principalTable: "Ptica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OsobinaPtica_PticeID",
                table: "OsobinaPtica",
                column: "PticeID");

            migrationBuilder.CreateIndex(
                name: "IX_PticaPodrucje_PodrucjeID",
                table: "PticaPodrucje",
                column: "PodrucjeID");

            migrationBuilder.CreateIndex(
                name: "IX_PticaPodrucje_PticaID",
                table: "PticaPodrucje",
                column: "PticaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OsobinaPtica");

            migrationBuilder.DropTable(
                name: "PticaPodrucje");

            migrationBuilder.DropTable(
                name: "Osobina");

            migrationBuilder.DropTable(
                name: "Podrucje");

            migrationBuilder.DropTable(
                name: "Ptica");
        }
    }
}
