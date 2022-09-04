using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Data.Migrations
{
    public partial class AddCategoryCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Categories",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Url",
                table: "Categories",
                column: "Url",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_Url",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Categories");
        }
    }
}
