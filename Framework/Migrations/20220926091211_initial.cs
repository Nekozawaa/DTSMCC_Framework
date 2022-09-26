using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perusahaans",
                columns: table => new
                {
                    idPerusahan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipePerusahaan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perusahaans", x => x.idPerusahan);
                });

            migrationBuilder.CreateTable(
                name: "Provinsis",
                columns: table => new
                {
                    idProvinsi = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namaProvinsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinsis", x => x.idProvinsi);
                });

            migrationBuilder.CreateTable(
                name: "Penempatans",
                columns: table => new
                {
                    idPenempatan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namaPerusahaan = table.Column<string>(nullable: true),
                    idPerusahaan = table.Column<int>(nullable: false),
                    idProvinsi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penempatans", x => x.idPenempatan);
                    table.ForeignKey(
                        name: "FK_Penempatans_Perusahaans_idPerusahaan",
                        column: x => x.idPerusahaan,
                        principalTable: "Perusahaans",
                        principalColumn: "idPerusahan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Penempatans_Provinsis_idProvinsi",
                        column: x => x.idProvinsi,
                        principalTable: "Provinsis",
                        principalColumn: "idProvinsi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Penempatans_idPerusahaan",
                table: "Penempatans",
                column: "idPerusahaan");

            migrationBuilder.CreateIndex(
                name: "IX_Penempatans_idProvinsi",
                table: "Penempatans",
                column: "idProvinsi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Penempatans");

            migrationBuilder.DropTable(
                name: "Perusahaans");

            migrationBuilder.DropTable(
                name: "Provinsis");
        }
    }
}
