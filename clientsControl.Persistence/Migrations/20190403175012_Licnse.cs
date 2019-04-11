using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class Licnse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    REUP = table.Column<string>(maxLength: 16, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Descontinued = table.Column<bool>(nullable: false, defaultValue: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    VersionId = table.Column<Guid>(nullable: false),
                    StockTypeId = table.Column<Guid>(nullable: false),
                    ClasificationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_License_ClientClasification",
                        column: x => x.ClasificationId,
                        principalTable: "LicenseClientClasification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseClient",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseStockType",
                        column: x => x.StockTypeId,
                        principalTable: "StockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseVersion",
                        column: x => x.VersionId,
                        principalTable: "AssetsVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ClasificationId",
                table: "Licenses",
                column: "ClasificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ClientId",
                table: "Licenses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_StockTypeId",
                table: "Licenses",
                column: "StockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_VersionId",
                table: "Licenses",
                column: "VersionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licenses");
        }
    }
}
