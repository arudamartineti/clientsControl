using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class assetsCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Clients",
            //    table: "Client");

            //migrationBuilder.RenameTable(
            //    name: "Clients",
            //    newName: "Client");

            migrationBuilder.AddColumn<string>(
                name: "AssetsCode",
                table: "Client",
                nullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Client",
            //    table: "Client",
            //    column: "Id")
            //    .Annotation("SqlServer:Clustered", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Client",
            //    table: "Client");

            migrationBuilder.DropColumn(
                name: "AssetsCode",
                table: "Client");

            //migrationBuilder.RenameTable(
            //    name: "Client",
            //    newName: "Clients");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Clients",
            //    table: "Clients",
            //    column: "Id")
            //    .Annotation("SqlServer:Clustered", true);
        }
    }
}
