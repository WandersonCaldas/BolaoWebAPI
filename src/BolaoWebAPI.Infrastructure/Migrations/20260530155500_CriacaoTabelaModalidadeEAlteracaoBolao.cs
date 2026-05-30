using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoWebAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaModalidadeEAlteracaoBolao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ModalidadeId",
                schema: "bolao",
                table: "Boloes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Modalidades",
                schema: "bolao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuantidadeMinimaNumeros = table.Column<int>(type: "int", nullable: false),
                    QuantidadeMaximaNumeros = table.Column<int>(type: "int", nullable: false),
                    NumeroMinimo = table.Column<int>(type: "int", nullable: false),
                    NumeroMaximo = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boloes_ModalidadeId",
                schema: "bolao",
                table: "Boloes",
                column: "ModalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boloes_Modalidades_ModalidadeId",
                schema: "bolao",
                table: "Boloes",
                column: "ModalidadeId",
                principalSchema: "bolao",
                principalTable: "Modalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boloes_Modalidades_ModalidadeId",
                schema: "bolao",
                table: "Boloes");

            migrationBuilder.DropTable(
                name: "Modalidades",
                schema: "bolao");

            migrationBuilder.DropIndex(
                name: "IX_Boloes_ModalidadeId",
                schema: "bolao",
                table: "Boloes");

            migrationBuilder.DropColumn(
                name: "ModalidadeId",
                schema: "bolao",
                table: "Boloes");
        }
    }
}
