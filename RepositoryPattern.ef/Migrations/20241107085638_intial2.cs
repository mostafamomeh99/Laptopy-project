using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryPattern.ef.Migrations
{
    /// <inheritdoc />
    public partial class intial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Beands_BrandID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beands",
                table: "Beands");

            migrationBuilder.RenameTable(
                name: "Beands",
                newName: "Brands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Beands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beands",
                table: "Beands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Beands_BrandID",
                table: "Products",
                column: "BrandID",
                principalTable: "Beands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
