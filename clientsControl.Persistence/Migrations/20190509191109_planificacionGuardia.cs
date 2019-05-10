using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class planificacionGuardia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SupportDayPlanificationId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SupportPlanification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Month = table.Column<byte>(maxLength: 12, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Confirmed = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportPlanification", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "SupportDayPlanification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateSupport = table.Column<DateTime>(nullable: false),
                    NotWorkHolliday = table.Column<bool>(nullable: false),
                    SupportPlanificationId = table.Column<Guid>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportDayPlanification", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SupportDayPlanification_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportDayPlanification_SupportPlanification_SupportPlanificationId",
                        column: x => x.SupportPlanificationId,
                        principalTable: "SupportPlanification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SupportDayPlanificationId",
                table: "AspNetUsers",
                column: "SupportDayPlanificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportDayPlanification_ApplicationUserId",
                table: "SupportDayPlanification",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportDayPlanification_SupportPlanificationId",
                table: "SupportDayPlanification",
                column: "SupportPlanificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SupportDayPlanification_SupportDayPlanificationId",
                table: "AspNetUsers",
                column: "SupportDayPlanificationId",
                principalTable: "SupportDayPlanification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SupportDayPlanification_SupportDayPlanificationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SupportDayPlanification");

            migrationBuilder.DropTable(
                name: "SupportPlanification");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SupportDayPlanificationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SupportDayPlanificationId",
                table: "AspNetUsers");
        }
    }
}
