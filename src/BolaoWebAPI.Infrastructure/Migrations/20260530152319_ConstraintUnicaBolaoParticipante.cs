using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoWebAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConstraintUnicaBolaoParticipante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BolaoParticipantes_BolaoId",
                schema: "bolao",
                table: "BolaoParticipantes");

            migrationBuilder.CreateIndex(
                name: "IX_BolaoParticipantes_BolaoId_ParticipanteId",
                schema: "bolao",
                table: "BolaoParticipantes",
                columns: new[] { "BolaoId", "ParticipanteId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BolaoParticipantes_BolaoId_ParticipanteId",
                schema: "bolao",
                table: "BolaoParticipantes");

            migrationBuilder.CreateIndex(
                name: "IX_BolaoParticipantes_BolaoId",
                schema: "bolao",
                table: "BolaoParticipantes",
                column: "BolaoId");
        }
    }
}
