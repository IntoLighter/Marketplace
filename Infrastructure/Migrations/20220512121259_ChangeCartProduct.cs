using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangeCartProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_AspNetUsers_AppUserId",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Products_ProductId",
                table: "CartProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct");

            migrationBuilder.DropIndex(
                name: "IX_CartProduct_AppUserId",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "CartProduct");

            migrationBuilder.RenameTable(
                name: "CartProduct",
                newName: "CartProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartProducts",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CartProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProducts",
                table: "CartProducts",
                columns: new[] { "Id", "ShopName", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_UserId",
                table: "CartProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_AspNetUsers_UserId",
                table: "CartProducts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Products_Id",
                table: "CartProducts",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_AspNetUsers_UserId",
                table: "CartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Products_Id",
                table: "CartProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProducts",
                table: "CartProducts");

            migrationBuilder.DropIndex(
                name: "IX_CartProducts_UserId",
                table: "CartProducts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartProducts");

            migrationBuilder.RenameTable(
                name: "CartProducts",
                newName: "CartProduct");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CartProduct",
                newName: "ProductId");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "CartProduct",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct",
                columns: new[] { "ProductId", "ShopName" });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_AppUserId",
                table: "CartProduct",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_AspNetUsers_AppUserId",
                table: "CartProduct",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Products_ProductId",
                table: "CartProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
