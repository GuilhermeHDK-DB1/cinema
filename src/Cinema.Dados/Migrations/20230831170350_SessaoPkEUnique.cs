using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Dados.Migrations
{
    /// <inheritdoc />
    public partial class SessaoPkEUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Sessao",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_filme_id_sala_id_horario",
                table: "Sessao",
                columns: new[] { "filme_id", "sala_id", "horario" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_filme_id_sala_id_horario",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Sessao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao",
                columns: new[] { "filme_id", "sala_id", "horario" });
        }
    }
}
