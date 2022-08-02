using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabysitterFy.UI.WebAPI.Migrations
{
    public partial class AddAddressAndProvince : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parent_Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parent_Province",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f3692426-829d-48fe-a86b-847cdb067c42");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e2b8275a-822f-4b69-b0e9-817b29cd9dce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "56095562-c228-4598-80cd-afaccc301b05");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "5b982145-cab9-4068-ae50-7b0b186dba85");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e131d47-e8f8-4df4-a96e-a25181cdc1a4", "AQAAAAEAACcQAAAAEK8uVMi+W4i7sJ5i76eN/0GhON1HKHRU9dVN5ESDW6aXrinO6RKkg4IIqJh5Kw+xkQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Parent_Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Parent_Province",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6ac3dfb1-d289-4072-ba4b-8885ce3e8e6f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9f5eac4a-2418-4e57-bbb7-e2fb843034a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "fc029cee-bd2e-4b2b-ac82-6e6317e50a58");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "39266752-f2e3-4817-8477-aec9cb77bbdd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "77ace527-bdfe-4ea8-977d-ae6376f26a0d", "AQAAAAEAACcQAAAAEOP3R72Oo8RJp2+Ol18BnG1ToTbn592TG/DBgesoVzvtd8wzOIy5D8GzQQ3xagFZsA==" });
        }
    }
}
