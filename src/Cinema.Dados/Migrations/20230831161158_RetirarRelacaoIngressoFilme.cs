using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Dados.Migrations
{
    /// <inheritdoc />
    public partial class RetirarRelacaoIngressoFilme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Filme_filme_id",
                table: "Ingresso");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_filme_id",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "filme_id",
                table: "Ingresso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "filme_id",
                table: "Ingresso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_filme_id",
                table: "Ingresso",
                column: "filme_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Filme_filme_id",
                table: "Ingresso",
                column: "filme_id",
                principalTable: "Filme",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
