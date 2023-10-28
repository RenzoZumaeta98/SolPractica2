using Microsoft.EntityFrameworkCore.Migrations;

namespace SolPractica2.Migrations
{
    public partial class MigracionInicialPractica2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    cod = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    dni = table.Column<string>(nullable: true),
                    fechaNacimiento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.cod);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    cod = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    nota = table.Column<int>(nullable: false),
                    alumnocod = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.cod);
                    table.ForeignKey(
                        name: "FK_Notas_Alumnos_alumnocod",
                        column: x => x.alumnocod,
                        principalTable: "Alumnos",
                        principalColumn: "cod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_alumnocod",
                table: "Notas",
                column: "alumnocod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Alumnos");
        }
    }
}
