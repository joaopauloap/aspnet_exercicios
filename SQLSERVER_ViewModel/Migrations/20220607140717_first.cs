using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_SQLSERVER.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Contrato_Trabalho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_Contratacao = table.Column<DateTime>(type: "date", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Contrato_Trabalho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Plano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Plano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Veterinario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ContratoTrabalhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Veterinario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Veterinario_Tbl_Contrato_Trabalho_ContratoTrabalhoId",
                        column: x => x.ContratoTrabalhoId,
                        principalTable: "Tbl_Contrato_Trabalho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dt_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Castrado = table.Column<bool>(type: "bit", nullable: false),
                    Especie = table.Column<int>(type: "int", nullable: false),
                    PlanoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Animal_Tbl_Plano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Tbl_Plano",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Animal_Veterinario",
                columns: table => new
                {
                    VeterinarioId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Animal_Veterinario", x => new { x.AnimalId, x.VeterinarioId });
                    table.ForeignKey(
                        name: "FK_Tbl_Animal_Veterinario_Tbl_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Tbl_Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Animal_Veterinario_Tbl_Veterinario_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Tbl_Veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Animal_PlanoId",
                table: "Tbl_Animal",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Animal_Veterinario_VeterinarioId",
                table: "Tbl_Animal_Veterinario",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Veterinario_ContratoTrabalhoId",
                table: "Tbl_Veterinario",
                column: "ContratoTrabalhoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Animal_Veterinario");

            migrationBuilder.DropTable(
                name: "Tbl_Animal");

            migrationBuilder.DropTable(
                name: "Tbl_Veterinario");

            migrationBuilder.DropTable(
                name: "Tbl_Plano");

            migrationBuilder.DropTable(
                name: "Tbl_Contrato_Trabalho");
        }
    }
}
