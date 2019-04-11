using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class Configuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);*/

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientConsecutive = table.Column<int>(nullable: false),
                    LicenceConsecutive = table.Column<int>(nullable: false),
                    SmtpServer = table.Column<string>(maxLength: 255, nullable: true),
                    SmtpPort = table.Column<string>(nullable: true),
                    StmpUser = table.Column<string>(maxLength: 255, nullable: true),
                    SmtpPassword = table.Column<string>(maxLength: 255, nullable: true),
                    GeneratedPaymentControlPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);
        }
    }
}
