using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class LicenseDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseDetail",
                columns: table => new
                {
                    ModuleId = table.Column<Guid>(nullable: false),
                    LicenceId = table.Column<Guid>(nullable: false),
                    Licencias = table.Column<int>(nullable: false),
                    PcAdicionales = table.Column<int>(nullable: false),
                    PcConsultas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseDetail", x => new { x.LicenceId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_LicenseDetail_Licenses_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseDetail_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicenseDetail_ModuleId",
                table: "LicenseDetail",
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseDetail");
        }
    }
}
