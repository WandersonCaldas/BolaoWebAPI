using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoWebAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaResultado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resultados",
                schema: "bolao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolaoId = table.Column<long>(type: "bigint", nullable: false),
                    NumerosSorteados = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataResultado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultados_Boloes_BolaoId",
                        column: x => x.BolaoId,
                        principalSchema: "bolao",
                        principalTable: "Boloes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_BolaoId",
                schema: "bolao",
                table: "Resultados",
                column: "BolaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resultados",
                schema: "bolao");
        }
    }
}
