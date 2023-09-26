using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PontoMVC.Migrations
{
    public partial class EntradaESaida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FimJornada",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InicioJornada",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FimJornada",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "InicioJornada",
                table: "Usuarios");
        }
    }
}
