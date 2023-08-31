using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Dados.Migrations
{
    /// <inheritdoc />
    public partial class RetirarRelacaoIngressoSala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Sala_sala_id",
                table: "Ingresso");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_sala_id",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "sala_id",
                table: "Ingresso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sala_id",
                table: "Ingresso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_sala_id",
                table: "Ingresso",
                column: "sala_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Sala_sala_id",
                table: "Ingresso",
                column: "sala_id",
                principalTable: "Sala",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
