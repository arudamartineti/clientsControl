using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class InicioFinalPostventa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoFinalPostVenta",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "MesFinalPostVenta",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "MesInicioPostVenta",
                table: "Contract");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinalPostVenta",
                table: "Contract",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InicioPostVenta",
                table: "Contract",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPostVenta",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "InicioPostVenta",
                table: "Contract");

            migrationBuilder.AddColumn<byte>(
                name: "AnoFinalPostVenta",
                table: "Contract",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MesFinalPostVenta",
                table: "Contract",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MesInicioPostVenta",
                table: "Contract",
                maxLength: 12,
                nullable: true);
        }
    }
}
