using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Karim_eshop.Data.Context.Migrations
{
    public partial class UpdateEntityProductImageField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a26cce5-e43a-45e3-b319-7d2f54eb4e56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f88570c9-716d-48b9-adbf-cfb640a7b966");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Products",
                newName: "Photo");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "165d3afc-90b7-46ae-8c1c-38682489619f", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3a9aa71-c361-49fa-a2fd-e6e856ef5dd6", "2", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "165d3afc-90b7-46ae-8c1c-38682489619f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3a9aa71-c361-49fa-a2fd-e6e856ef5dd6");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Products",
                newName: "PictureUrl");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a26cce5-e43a-45e3-b319-7d2f54eb4e56", "2", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f88570c9-716d-48b9-adbf-cfb640a7b966", "1", "Admin", "Admin" });
        }
    }
}
