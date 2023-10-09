using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universidad.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatecs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    id_curso = table.Column<int>(type: "INTEGER", nullable: false),
                    titulo = table.Column<string>(type: "TEXT", nullable: true),
                    creditos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.id_curso);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    id_estudiante = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha_de_inscripcion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.id_estudiante);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    id_inscripcion = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_curso = table.Column<int>(type: "INTEGER", nullable: false),
                    id_estudiante = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.id_inscripcion);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Curso_id_curso",
                        column: x => x.id_curso,
                        principalTable: "Curso",
                        principalColumn: "id_curso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Estudiante_id_estudiante",
                        column: x => x.id_estudiante,
                        principalTable: "Estudiante",
                        principalColumn: "id_estudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_id_curso",
                table: "Inscripcion",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_id_estudiante",
                table: "Inscripcion",
                column: "id_estudiante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Estudiante");
        }
    }
}
