using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabysitterFy.UI.WebAPI.Migrations
{
    public partial class addparent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfChildren",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Parent_DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parent_Firstname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parent_Lastname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfChildren",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Parent_DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Parent_Firstname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Parent_Lastname",
                table: "AspNetUsers");
        }
    }
}
