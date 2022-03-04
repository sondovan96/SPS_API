using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Data.Migrations
{
    public partial class AddTablePromotionProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Product");

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalPrice",
                table: "Product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "Stock",
                table: "Product",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    SortImage = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    ApplyForAll = table.Column<bool>(nullable: false),
                    DiscountPercent = table.Column<int>(nullable: true),
                    DiscountAmount = table.Column<decimal>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProductIds = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "e835e2a1-6b6f-4706-9675-a4f37fb80cef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "6f2f641d-9e50-4fd5-9dd6-34f917621e49");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "b1c3b38c-59c0-4d58-a555-3c4393fc06f4", new DateTime(2022, 3, 4, 23, 44, 16, 732, DateTimeKind.Local).AddTicks(1708), new DateTime(2022, 3, 4, 23, 44, 16, 731, DateTimeKind.Local).AddTicks(4376), "AQAAAAEAACcQAAAAENBvi9gbaEOX2IYgedmol01gwtSBqHmi6Q+tgQ1DRebM5f+2yO0S7qTqX0QjQWumhQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductID",
                table: "ProductImage",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category",
                column: "ParentId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropIndex(
                name: "IX_Category_ParentId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Quantity",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "5d179868-3275-464b-aa9c-cd1e768577fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "5ffe5615-db59-4578-820f-6f5ee9f855e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "5a38512b-aca7-48d2-860c-ed252c0ea225", new DateTime(2022, 3, 4, 0, 32, 43, 509, DateTimeKind.Local).AddTicks(4935), new DateTime(2022, 3, 4, 0, 32, 43, 508, DateTimeKind.Local).AddTicks(7047), "AQAAAAEAACcQAAAAEHSvraDVMJ/OR1cHeyaxh2m2IPN1Lb4eriX4AyQDtrDIYXy36W7FFZOViD0k1m56cA==" });
        }
    }
}
