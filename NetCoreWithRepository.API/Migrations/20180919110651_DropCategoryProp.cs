using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreWithRepository.API.Migrations
{
    public partial class DropCategoryProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deneme",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deneme",
                table: "Categories",
                nullable: true);
        }
    }
}
