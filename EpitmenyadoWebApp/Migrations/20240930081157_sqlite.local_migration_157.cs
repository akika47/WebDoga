using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpitmenyadoWebApp.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_157 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Telkeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdoSzam = table.Column<int>(type: "INTEGER", nullable: false),
                    UtcaNev = table.Column<string>(type: "TEXT", nullable: false),
                    HazSzam = table.Column<string>(type: "TEXT", nullable: false),
                    Sav = table.Column<char>(type: "TEXT", nullable: false),
                    AlapTerulet = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telkeks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telkeks");
        }
    }
}
