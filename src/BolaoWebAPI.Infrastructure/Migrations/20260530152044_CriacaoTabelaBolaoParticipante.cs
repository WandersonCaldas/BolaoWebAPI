using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoWebAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaBolaoParticipante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BolaoParticipantes",
                schema: "bolao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolaoId = table.Column<long>(type: "bigint", nullable: false),
                    ParticipanteId = table.Column<long>(type: "bigint", nullable: false),
                    QuantidadeCotas = table.Column<int>(type: "int", nullable: false),
                    ValorCota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolaoParticipantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BolaoParticipantes_Boloes_BolaoId",
                        column: x => x.BolaoId,
                        principalSchema: "bolao",
                        principalTable: "Boloes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BolaoParticipantes_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalSchema: "bolao",
                        principalTable: "Participantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BolaoParticipantes_BolaoId",
                schema: "bolao",
                table: "BolaoParticipantes",
                column: "BolaoId");

            migrationBuilder.CreateIndex(
                name: "IX_BolaoParticipantes_ParticipanteId",
                schema: "bolao",
                table: "BolaoParticipantes",
                column: "ParticipanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BolaoParticipantes",
                schema: "bolao");
        }
    }
}
