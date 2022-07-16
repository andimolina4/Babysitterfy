using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabysitterfyApp.Migrations
{
    public partial class AddWorkTimeBabysitter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkTimeEnd",
                table: "BabySitter");

            migrationBuilder.DropColumn(
                name: "WorkTimeStart",
                table: "BabySitter");

            migrationBuilder.AddColumn<int>(
                name: "WorkTime",
                table: "BabySitter",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkTime",
                table: "BabySitter");

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkTimeEnd",
                table: "BabySitter",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkTimeStart",
                table: "BabySitter",
                type: "datetime2",
                nullable: true);
        }
    }
}
