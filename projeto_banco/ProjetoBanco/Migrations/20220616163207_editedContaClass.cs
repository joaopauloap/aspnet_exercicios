using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBanco.Migrations
{
    public partial class editedContaClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Conta",
                newName: "ContaId");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "AspNetUsers",
                newName: "TipoCliente");

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ContaId",
                table: "AspNetUsers",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Conta_ContaId",
                table: "AspNetUsers",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "ContaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Conta_ContaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ContaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ContaId",
                table: "Conta",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TipoCliente",
                table: "AspNetUsers",
                newName: "Tipo");
        }
    }
}
