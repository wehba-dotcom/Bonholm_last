using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AfgangTilgangApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AfgangTilgang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sogn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SogneNo = table.Column<int>(type: "int", nullable: true),
                    Billedfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Folieside = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Liste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aar = table.Column<int>(type: "int", nullable: true),
                    No = table.Column<int>(type: "int", nullable: true),
                    Familieno = table.Column<int>(type: "int", nullable: true),
                    Fornavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sleagtsnavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alder = table.Column<int>(type: "int", nullable: true),
                    Fodeaar = table.Column<int>(type: "int", nullable: true),
                    Haandtering = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hvorhenrejst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hvorfraankommet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HvoriJeavnfReg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anmearkning = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfgangTilgang", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfgangTilgang");
        }
    }
}
