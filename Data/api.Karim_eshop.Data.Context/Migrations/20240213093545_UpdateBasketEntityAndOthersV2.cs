using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Karim_eshop.Data.Context.Migrations
{
    public partial class UpdateBasketEntityAndOthersV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Baskets_BasketId",
                table: "BasketItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92db2428-8c6d-4461-9047-0b30daecdd12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c40f8e46-de7b-454d-9cf9-4b983c422151");

            migrationBuilder.AlterColumn<int>(
                name: "BasketId",
                table: "BasketItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c72e58c8-3fe0-4fbc-bdfd-3358b77468d0", "2", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2b99bbc-015f-4130-85f0-7ce4819c001a", "1", "Admin", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Baskets_BasketId",
                table: "BasketItem",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Baskets_BasketId",
                table: "BasketItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c72e58c8-3fe0-4fbc-bdfd-3358b77468d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2b99bbc-015f-4130-85f0-7ce4819c001a");

            migrationBuilder.AlterColumn<int>(
                name: "BasketId",
                table: "BasketItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92db2428-8c6d-4461-9047-0b30daecdd12", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c40f8e46-de7b-454d-9cf9-4b983c422151", "2", "User", "User" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Baskets_BasketId",
                table: "BasketItem",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id");
        }
    }
}
