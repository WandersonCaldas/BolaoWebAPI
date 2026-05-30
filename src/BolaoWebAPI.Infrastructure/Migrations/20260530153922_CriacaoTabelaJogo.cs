using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoWebAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaJogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogos",
                schema: "bolao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolaoId = table.Column<long>(type: "bigint", nullable: false),
                    Numeros = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Boloes_BolaoId",
                        column: x => x.BolaoId,
                        principalSchema: "bolao",
                        principalTable: "Boloes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_BolaoId",
                schema: "bolao",
                table: "Jogos",
                column: "BolaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos",
                schema: "bolao");
        }
    }
}
