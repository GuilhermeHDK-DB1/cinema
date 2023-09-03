using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Dados.Migrations
{
    /// <inheritdoc />
    public partial class ExcluindoSessaoIngresso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessao_Ingresso");

            migrationBuilder.AddColumn<int>(
                name: "sessao_id",
                table: "Ingresso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_sessao_id",
                table: "Ingresso",
                column: "sessao_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Sessao_sessao_id",
                table: "Ingresso",
                column: "sessao_id",
                principalTable: "Sessao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Sessao_sessao_id",
                table: "Ingresso");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_sessao_id",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "sessao_id",
                table: "Ingresso");

            migrationBuilder.CreateTable(
                name: "Sessao_Ingresso",
                columns: table => new
                {
                    sessao_id = table.Column<int>(type: "int", nullable: false),
                    ingresso_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao_Ingresso", x => new { x.sessao_id, x.ingresso_id });
                    table.ForeignKey(
                        name: "FK_Sessao_Ingresso_Ingresso_ingresso_id",
                        column: x => x.ingresso_id,
                        principalTable: "Ingresso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessao_Ingresso_Sessao_sessao_id",
                        column: x => x.sessao_id,
                        principalTable: "Sessao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_Ingresso_ingresso_id",
                table: "Sessao_Ingresso",
                column: "ingresso_id");
        }
    }
}
