using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OsobinaPtica");

            migrationBuilder.RenameColumn(
                name: "Vrednost",
                table: "Osobina",
                newName: "Vrednost1");

            migrationBuilder.AddColumn<int>(
                name: "OsobineID",
                table: "Ptica",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vrednost2",
                table: "Osobina",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vrednost3",
                table: "Osobina",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ptica_OsobineID",
                table: "Ptica",
                column: "OsobineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ptica_Osobina_OsobineID",
                table: "Ptica",
                column: "OsobineID",
                principalTable: "Osobina",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ptica_Osobina_OsobineID",
                table: "Ptica");

            migrationBuilder.DropIndex(
                name: "IX_Ptica_OsobineID",
                table: "Ptica");

            migrationBuilder.DropColumn(
                name: "OsobineID",
                table: "Ptica");

            migrationBuilder.DropColumn(
                name: "Vrednost2",
                table: "Osobina");

            migrationBuilder.DropColumn(
                name: "Vrednost3",
                table: "Osobina");

            migrationBuilder.RenameColumn(
                name: "Vrednost1",
                table: "Osobina",
                newName: "Vrednost");

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

            migrationBuilder.CreateIndex(
                name: "IX_OsobinaPtica_PticeID",
                table: "OsobinaPtica",
                column: "PticeID");
        }
    }
}
