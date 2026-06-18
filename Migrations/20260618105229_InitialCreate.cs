using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projekt.NET.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Namn = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recept",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titel = table.Column<string>(type: "TEXT", nullable: false),
                    Beskrivning = table.Column<string>(type: "TEXT", nullable: true),
                    Instruktioner = table.Column<string>(type: "TEXT", nullable: true),
                    Tillagningstid = table.Column<int>(type: "INTEGER", nullable: false),
                    KategoriId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recept", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recept_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Namn = table.Column<string>(type: "TEXT", nullable: false),
                    Mängd = table.Column<string>(type: "TEXT", nullable: true),
                    Enhet = table.Column<string>(type: "TEXT", nullable: true),
                    ReceptId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingrediens_Recept_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recept",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediens_ReceptId",
                table: "Ingrediens",
                column: "ReceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Recept_KategoriId",
                table: "Recept",
                column: "KategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingrediens");

            migrationBuilder.DropTable(
                name: "Recept");

            migrationBuilder.DropTable(
                name: "Kategori");
        }
    }
}
