using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenFinal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreadorId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Usuario_CreadorId",
                        column: x => x.CreadorId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EtiquetaNotas",
                columns: table => new
                {
                    EtiquetaId = table.Column<int>(type: "int", nullable: false),
                    NotaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiquetaNotas", x => new { x.EtiquetaId, x.NotaId });
                    table.ForeignKey(
                        name: "FK_EtiquetaNotas_Etiquetas_EtiquetaId",
                        column: x => x.EtiquetaId,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtiquetaNotas_Notas_NotaId",
                        column: x => x.NotaId,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioNotas",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    NotaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioNotas", x => new { x.UsuarioId, x.NotaId });
                    table.ForeignKey(
                        name: "FK_UsuarioNotas_Notas_NotaId",
                        column: x => x.NotaId,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioNotas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetaNotas_NotaId",
                table: "EtiquetaNotas",
                column: "NotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_CreadorId",
                table: "Notas",
                column: "CreadorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioNotas_NotaId",
                table: "UsuarioNotas",
                column: "NotaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtiquetaNotas");

            migrationBuilder.DropTable(
                name: "UsuarioNotas");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
