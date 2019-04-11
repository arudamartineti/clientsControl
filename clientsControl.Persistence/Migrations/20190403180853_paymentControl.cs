using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class paymentControl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentControls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GeneratedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    LicenceId = table.Column<Guid>(nullable: false),
                    Localization = table.Column<string>(nullable: true),
                    SendByEmail = table.Column<bool>(nullable: false),
                    Public = table.Column<bool>(nullable: false),
                    SentByEmail = table.Column<bool>(nullable: false),
                    SentByEmailDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentControls_Licenses_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentControls_LicenceId",
                table: "PaymentControls",
                column: "LicenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentControls");
        }
    }
}
