using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_SQLSERVER.Migrations
{
    public partial class campodatahoraanimalveterinario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Animal_Veterinario",
                table: "Tbl_Animal_Veterinario");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHora",
                table: "Tbl_Animal_Veterinario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Animal_Veterinario",
                table: "Tbl_Animal_Veterinario",
                columns: new[] { "AnimalId", "VeterinarioId", "DataHora" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Animal_Veterinario",
                table: "Tbl_Animal_Veterinario");

            migrationBuilder.DropColumn(
                name: "DataHora",
                table: "Tbl_Animal_Veterinario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Animal_Veterinario",
                table: "Tbl_Animal_Veterinario",
                columns: new[] { "AnimalId", "VeterinarioId" });
        }
    }
}
