using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class Configuration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_ClientId",
                table: "Contacts",
                newName: "IX_Contacts_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_ClientId",
                table: "Contact",
                newName: "IX_Contact_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);
        }
    }
}
