using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clientsControl.Persistence.Migrations
{
    public partial class planificationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "SupportPlanification");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "SupportPlanification");

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanificationDate",
                table: "SupportPlanification",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanificationDate",
                table: "SupportPlanification");

            migrationBuilder.AddColumn<byte>(
                name: "Month",
                table: "SupportPlanification",
                maxLength: 12,
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "SupportPlanification",
                nullable: false,
                defaultValue: 0);
        }
    }
}
