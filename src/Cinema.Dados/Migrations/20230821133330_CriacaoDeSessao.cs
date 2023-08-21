using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Dados.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDeSessao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "classificacao",
                table: "Filme",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Sessao",
                columns: table => new
                {
                    filme_id = table.Column<int>(type: "int", nullable: false),
                    sala_id = table.Column<int>(type: "int", nullable: false),
                    horario = table.Column<DateTime>(type: "datetime", nullable: false),
                    idioma = table.Column<int>(type: "int", nullable: false),
                    encerrada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao", x => new { x.filme_id, x.sala_id });
                    table.ForeignKey(
                        name: "FK_Sessao_Filme_filme_id",
                        column: x => x.filme_id,
                        principalTable: "Filme",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessao_Sala_sala_id",
                        column: x => x.sala_id,
                        principalTable: "Sala",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_sala_id",
                table: "Sessao",
                column: "sala_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessao");

            migrationBuilder.DropColumn(
                name: "classificacao",
                table: "Filme");
        }
    }
}
