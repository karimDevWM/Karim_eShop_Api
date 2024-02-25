using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Karim_eshop.Data.Context.Migrations
{
    public partial class changePhotoToNullInUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a73b0b2e-5c56-4db7-bd9c-8283f13e5265");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d08d768d-f601-47d0-bbe7-d5cd0c14a91d", null, "Member", "MEMBER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "244e35ca-b4cd-4381-87e6-1ac94f12fced", "AQAAAAIAAYagAAAAELLHDuXX6tDJlGWX1U2gsPHypRpCT5lwAb7KziVXMQIsobo9nnIGFWt0jiT7kWx5/A==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureUrl",
                value: "/images/products/robe_marie_or_diamant.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "PictureUrl",
                value: "/images/products/sac_peau_gazelle.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "PictureUrl",
                value: "/images/products/cendrier_en_or.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "PictureUrl",
                value: "/images/products/pipe_en_bois_noble.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d08d768d-f601-47d0-bbe7-d5cd0c14a91d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Photo",
                keyValue: null,
                column: "Photo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a73b0b2e-5c56-4db7-bd9c-8283f13e5265", null, "Member", "MEMBER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92708641-a892-415a-835d-b000cde4193a", "AQAAAAIAAYagAAAAEHirAQ5mO2R1B+Th2bLoySMD+fXZCb15DAZQq/RanV9Kkcb1QtzBYAuZrGo/HJTsHQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureUrl",
                value: "/images/products/robe_marié_or_diamant.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "PictureUrl",
                value: "/images/products/sac_peau_gazelle");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "PictureUrl",
                value: "/images/products/cendrier en or.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "PictureUrl",
                value: "/images/products/pipe_en_bois_noble");
        }
    }
}
