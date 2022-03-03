using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Data.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    HotProduct = table.Column<bool>(nullable: false, defaultValue: false),
                    FeaturedProduct = table.Column<bool>(nullable: false, defaultValue: false),
                    Quantity = table.Column<long>(nullable: false, defaultValue: 0L),
                    Size = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    IdCategory = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "4bc7b411-66d0-47f7-b99e-7f3a58984dbf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "6c0f6db8-6f07-45e8-85bf-8c955cee7aae");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "c8ca5f9a-1027-4d9c-b082-243e0f975c96", new DateTime(2022, 3, 3, 17, 7, 29, 89, DateTimeKind.Local).AddTicks(7993), new DateTime(2022, 3, 3, 17, 7, 29, 89, DateTimeKind.Local).AddTicks(396), "AQAAAAEAACcQAAAAEMb9mb3NnluEnn8jmFG2Zr/FQ4cblXFNaSTch76ECpi3JtTt2enPH2X9IutJiz7Srg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdCategory",
                table: "Product",
                column: "IdCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "3dc4ab7b-5471-431b-bd9e-adf70921ec4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "edbd2e59-54b7-41e8-936d-7bbb36355628");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "22673857-7b55-49d7-9f30-cb0b464decb0", new DateTime(2022, 3, 2, 16, 3, 46, 515, DateTimeKind.Local).AddTicks(6988), new DateTime(2022, 3, 2, 16, 3, 46, 514, DateTimeKind.Local).AddTicks(9853), "AQAAAAEAACcQAAAAEF3LX6aDs0YZeIN01SQyN4sTRo3XiDqg9nLq/oEm2J0fR/aQwGxb1Hjksj8K9OgY0g==" });
        }
    }
}
