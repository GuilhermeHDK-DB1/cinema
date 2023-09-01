using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Dados.Migrations
{
    /// <inheritdoc />
    public partial class SessaoAlteracaoDeUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sessao_filme_id_sala_id_horario",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_sala_id",
                table: "Sessao");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_filme_id",
                table: "Sessao",
                column: "filme_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_sala_id_horario",
                table: "Sessao",
                columns: new[] { "sala_id", "horario" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sessao_filme_id",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_sala_id_horario",
                table: "Sessao");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_filme_id_sala_id_horario",
                table: "Sessao",
                columns: new[] { "filme_id", "sala_id", "horario" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_sala_id",
                table: "Sessao",
                column: "sala_id");
        }
    }
}
