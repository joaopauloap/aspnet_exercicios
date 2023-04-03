using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopApi.Migrations
{
    public partial class tabelaplano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanoId",
                table: "Animais",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Animais_PlanoId",
                table: "Animais",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animais_Tbl_Plano_PlanoId",
                table: "Animais",
                column: "PlanoId",
                principalTable: "Tbl_Plano",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animais_Tbl_Plano_PlanoId",
                table: "Animais");

            migrationBuilder.DropTable(
                name: "Tbl_Plano");

            migrationBuilder.DropIndex(
                name: "IX_Animais_PlanoId",
                table: "Animais");

            migrationBuilder.DropColumn(
                name: "PlanoId",
                table: "Animais");
        }
    }
}
