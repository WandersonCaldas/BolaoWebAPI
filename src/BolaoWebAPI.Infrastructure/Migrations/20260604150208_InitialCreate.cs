using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolaoWebAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bolao");

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

            migrationBuilder.CreateTable(
                name: "Participantes",
                schema: "bolao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boloes",
                schema: "bolao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModalidadeId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ValorCota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeCotas = table.Column<int>(type: "int", nullable: false),
                    DataSorteio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boloes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boloes_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalSchema: "bolao",
                        principalTable: "Modalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_BolaoParticipantes_BolaoId_ParticipanteId",
                schema: "bolao",
                table: "BolaoParticipantes",
                columns: new[] { "BolaoId", "ParticipanteId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BolaoParticipantes_ParticipanteId",
                schema: "bolao",
                table: "BolaoParticipantes",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Boloes_ModalidadeId",
                schema: "bolao",
                table: "Boloes",
                column: "ModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_BolaoId",
                schema: "bolao",
                table: "Jogos",
                column: "BolaoId");

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
                name: "BolaoParticipantes",
                schema: "bolao");

            migrationBuilder.DropTable(
                name: "Jogos",
                schema: "bolao");

            migrationBuilder.DropTable(
                name: "Resultados",
                schema: "bolao");

            migrationBuilder.DropTable(
                name: "Participantes",
                schema: "bolao");

            migrationBuilder.DropTable(
                name: "Boloes",
                schema: "bolao");

            migrationBuilder.DropTable(
                name: "Modalidades",
                schema: "bolao");
        }
    }
}
