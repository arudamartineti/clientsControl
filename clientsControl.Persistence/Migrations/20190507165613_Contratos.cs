using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class Contratos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    Numero = table.Column<string>(maxLength: 255, nullable: false),
                    Suplemento = table.Column<bool>(nullable: false, defaultValue: false),
                    NumeroSuplement = table.Column<int>(nullable: false, defaultValue: 0),
                    FechaEntrega = table.Column<DateTime>(nullable: true),
                    FechaFirma = table.Column<DateTime>(nullable: true),
                    FechaRecibido = table.Column<DateTime>(nullable: true),
                    IdInstalador = table.Column<string>(nullable: true),
                    Ubicacion = table.Column<string>(nullable: true),
                    Objeto = table.Column<string>(maxLength: 1024, nullable: false),
                    ImporteLicenciasCUC = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    ImporteLicenciasMN = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    ImportePostVentaCUC = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    ImprotePostVentaMN = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    MesInicioPostVenta = table.Column<byte>(maxLength: 12, nullable: true),
                    MesFinalPostVenta = table.Column<byte>(maxLength: 12, nullable: true),
                    AnoFinalPostVenta = table.Column<byte>(nullable: true),
                    Master = table.Column<string>(maxLength: 2048, nullable: true),
                    Discontinued = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Contract_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_AspNetUsers_IdInstalador",
                        column: x => x.IdInstalador,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ClientId",
                table: "Contract",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_IdInstalador",
                table: "Contract",
                column: "IdInstalador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contract");
        }
    }
}
