using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class ContactosLicencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LicenseId",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RecibeLicencias",
                table: "Contacts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LicenseId",
                table: "Contacts",
                column: "LicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Licenses_LicenseId",
                table: "Contacts",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Licenses_LicenseId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_LicenseId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "LicenseId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "RecibeLicencias",
                table: "Contacts");
        }
    }
}
