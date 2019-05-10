using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class nameimporte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImprotePostVentaMN",
                table: "Contract",
                newName: "ImportePostVentaMN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImportePostVentaMN",
                table: "Contract",
                newName: "ImprotePostVentaMN");
        }
    }
}
